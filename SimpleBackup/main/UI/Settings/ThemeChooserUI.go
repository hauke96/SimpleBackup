package Settings

import (
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type ThemeChooserUI struct {
	hBox          *gtk.HBox
	themeListView *gtk.ListStore
	themeList     []string
}

func NewThemeChooserUI() *ThemeChooserUI {
	frame := ThemeChooserUI{}

	frame.hBox = gtk.NewHBox(false, 0)
	frame.hBox.Add(gtk.NewLabel("fskdfgsudfgkjhvfskjd fhs dfisgh oo"))
	//	frame.hBox.Add(frame.createThemeList())

	return &frame
}

func (frame *ThemeChooserUI) createThemeList() *gtk.TreeView {
	box := gtk.NewHBox(false, 0)
	box.SetSizeRequest(-1, -1)

	list := gtk.NewListStore(glib.G_TYPE_STRING)
	frame.themeListView = list

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter, 0, "test")

	return tree
}
