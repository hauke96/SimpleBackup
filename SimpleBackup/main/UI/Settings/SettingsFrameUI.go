package Settings

import (
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type SettingsFrameUI struct {
	window       *gtk.Window
	treePaned    *gtk.HPaned
	settingsBox  *gtk.Box
	tree         *gtk.TreeView
	treeStore    *gtk.TreeStore
	themeChooser *ThemeChooser
	themeUIID    *gtk.TreePath
}

func NewSettingsFrameUI() *SettingsFrameUI {
	// ------------------------------
	// CREATE WINDOW AND UI
	// ------------------------------
	frame := SettingsFrameUI{}
	frame.themeChooser = NewThemeChooser()

	window := gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	window.SetSizeRequest(800, 600)
	window.SetTitle("SimpleBackup settings")
	window.Connect("destroy", func() { window.Destroy() })

	// ------------------------------
	// ADD TREE TO UI
	// ------------------------------
	hPaned := gtk.NewHPaned()
	hPaned.Add(frame.createTreeView())

	// ------------------------------
	// ADD DUMMY BOX
	// ------------------------------
	hBox := gtk.NewHBox(false, 0)
	hBox.Add(gtk.NewLabel("foo"))
	frame.settingsBox = &hBox.Box
	hPaned.Add(hBox)

	window.Add(hPaned)

	// ------------------------------
	// ADD WIDGETS TO UI
	// ------------------------------
	frame.treePaned = hPaned
	frame.window = window

	return &frame
}

func (frame *SettingsFrameUI) createTreeView() *gtk.HBox {
	hBox := gtk.NewHBox(false, 0)
	hBox.SetSizeRequest(250, -1)

	// ------------------------------
	// SET UP TREE STUFF
	// ------------------------------
	swin := gtk.NewScrolledWindow(nil, nil)

	store := gtk.NewTreeStore(glib.G_TYPE_STRING)
	tree := gtk.NewTreeView()
	swin.Add(tree)

	tree.SetModel(store.ToTreeModel())
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	// ------------------------------
	// CREATE CONNECT FOR CLICKS
	// ------------------------------
	tree.GetSelection().Connect("changed", func() {
		var path *gtk.TreePath
		var column *gtk.TreeViewColumn
		tree.GetCursor(&path, &column)
		switch {
		case path.Compare(*frame.themeUIID) == 0:
			frame.settingsBox.Ref()
			frame.treePaned.Remove(frame.settingsBox)
			frame.settingsBox = &frame.themeChooser.themeChooserUI.hBox.Box
			frame.treePaned.Add(frame.settingsBox)
			frame.settingsBox.ShowAll()
		}
	})

	// ------------------------------
	// FILL TREE
	// ------------------------------
	var iterp, iterc gtk.TreeIter

	store.Append(&iterp, nil)
	store.Set(&iterp, "User Interface")

	store.Append(&iterc, &iterp)
	store.Set(&iterc, "Language")

	store.Append(&iterc, &iterp)
	store.Set(&iterc, "Theme")
	frame.themeUIID = store.GetPath(&iterc)

	// ------------------------------
	// EXPAND
	// ------------------------------
	tree.ExpandAll()

	// ------------------------------
	// ADD TREE TO PANEL AND PANEL TO UI
	// ------------------------------
	hBox.Add(swin)
	frame.tree = tree
	frame.treeStore = store

	return hBox
}
