package Settings

import (
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type ThemeChooserUI struct {
	hBox          *gtk.VBox
	themeListView *gtk.ListStore
	themeList     []string
	buttonOK      *gtk.Button
	buttonCancel  *gtk.Button
}

func NewThemeChooserUI() *ThemeChooserUI {
	frame := ThemeChooserUI{}

	frame.hBox = gtk.NewVBox(false, 10)
	frame.hBox.SetBorderWidth(10)

	frame.hBox.Add(frame.createThemeList())
	frame.hBox.PackEnd(frame.createButtonArea(), false, false, 10)

	return &frame
}

func (frame *ThemeChooserUI) createThemeList() *gtk.HBox {
	box := gtk.NewHBox(false, 10)
	box.SetSizeRequest(0, 0)

	list := gtk.NewListStore(glib.G_TYPE_STRING)
	frame.themeListView = list

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("Existing themes:", gtk.NewCellRendererText(), "text", 0))

	box.Add(tree)

	return box
}

func (frame *ThemeChooserUI) fillThemeList(themeList []string) {
	frame.themeList = themeList
	var iter gtk.TreeIter
	for _, v := range frame.themeList {
		frame.themeListView.Append(&iter)
		frame.themeListView.SetValue(&iter, 0, v)
	}
}

func (frame *ThemeChooserUI) createButtonArea() *gtk.HBox {
	frame.buttonOK = gtk.NewButtonWithLabel("OK")
	frame.buttonOK.SetSizeRequest(100, 30)

	frame.buttonCancel = gtk.NewButtonWithLabel("Cancel")
	frame.buttonCancel.SetSizeRequest(100, 30)

	hBox := gtk.NewHBox(false, 10)

	hBox.PackEnd(frame.buttonOK, false, false, 0)
	hBox.PackEnd(frame.buttonCancel, false, false, 0)

	return hBox
}
