package Settings

import (
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type SettingsFrameUI struct {
	_window *gtk.Window
	_paned  *gtk.HPaned
	_tree   *gtk.TreeView
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
	frame._paned = hPaned
	//	frame._tree = tree
	frame._window = window

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
	var iter_p, iter_c gtk.TreeIter

	store.Append(&iter_p, nil)
	store.Set(&iter_p, "Oberfläche")

	store.Append(&iter_c, &iter_p)
	store.Set(&iter_c, "Sprache")

	// ------------------------------
	// Add tree to panel and panel to UI
	// ------------------------------
	hBox.Add(swin)
	frame._tree = tree

	return hBox
}
