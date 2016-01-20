package Settings

import (
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type SettingsFrameUI struct {
	window *gtk.Window
	paned  *gtk.HPaned
	tree   *gtk.TreeView
}

func NewSettingsFrameUI() *SettingsFrameUI {
	// ------------------------------
	// Create Window and UI
	// ------------------------------
	frame := SettingsFrameUI{}

	window := gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	window.SetSizeRequest(800, 600)
	window.SetTitle("SimpleBackup settings")
	window.Connect("destroy", func() { window.Destroy() })

	// ------------------------------
	// Add tree to UI
	// ------------------------------
	hPaned := gtk.NewHPaned()
	hPaned.Add(frame.createTreeView())

	hBox := gtk.NewHBox(false, 0)
	hBox.Add(gtk.NewLabel("foo"))
	hPaned.Add(hBox)

	window.Add(hPaned)

	// ------------------------------
	// Add Widgets to UI
	// ------------------------------
	frame.paned = hPaned
	//	frame.tree = tree
	frame.window = window

	return &frame
}

func (frame *SettingsFrameUI) createTreeView() *gtk.HBox {
	hBox := gtk.NewHBox(false, 0)
	hBox.SetSizeRequest(250, -1)

	// ------------------------------
	// Set up Tree stuff
	// ------------------------------
	swin := gtk.NewScrolledWindow(nil, nil)

	store := gtk.NewTreeStore(glib.G_TYPE_STRING)
	tree := gtk.NewTreeView()
	swin.Add(tree)

	tree.SetModel(store.ToTreeModel())
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	// ------------------------------
	// Fill Tree
	// ------------------------------
	var iterp, iterc gtk.TreeIter

	store.Append(&iterp, nil)
	store.Set(&iterp, "Oberfläche")

	store.Append(&iterc, &iterp)
	store.Set(&iterc, "Sprache")

	// ------------------------------
	// Add tree to panel and panel to UI
	// ------------------------------
	hBox.Add(swin)
	frame.tree = tree

	return hBox
}
