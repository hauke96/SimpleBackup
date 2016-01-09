package UI

import (
	"C"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type BackupUI struct {
	_box *gtk.HBox
}

func NewBackupUI() *BackupUI {
	backupUI := BackupUI{}
	backupUI.createBackupUIPanel()
	return &backupUI
}

func (backupUI *BackupUI) createBackupUIPanel() {
	hBox := gtk.NewHBox(false, 1)

	hBox.Add(backupUI.createBackupList())
	alignment := gtk.NewAlignment(0, 0.5, 0, 0)
	alignment.Add(backupUI.createButtonArea())
	hBox.PackStart(alignment, false, false, 0)
	hBox.Add(backupUI.createRunningList())

	backupUI._box = hBox
}

func (backupUI *BackupUI) createBackupList() *gtk.VBox {
	vBox := gtk.NewVBox(false, 10)
	vBox.SetBorderWidth(10)

	alignment := gtk.NewAlignment(0, 0, 0, 0)
	label := gtk.NewLabel("Alle Backup Jobs:")
	alignment.Add(label)
	vBox.PackStart(alignment, false, false, 0)

	list := gtk.NewListStore(glib.G_TYPE_STRING)

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter,
		0, "hallo")

	vBox.Add(tree)

	return vBox
}

func (backupUI *BackupUI) createButtonArea() *gtk.VBox {
	vBox := gtk.NewVBox(false, 10)

	button1 := gtk.NewButtonWithLabel("Start Job0")
	vBox.Add(button1)
	button2 := gtk.NewButtonWithLabel("Start Job1")
	vBox.Add(button2)
	button3 := gtk.NewButtonWithLabel("Start Job2")
	vBox.Add(button3)

	return vBox
}

func (backupUI *BackupUI) createRunningList() *gtk.VBox {
	vBox := gtk.NewVBox(false, 10)
	vBox.SetBorderWidth(10)

	alignment := gtk.NewAlignment(0, 0, 0, 0)
	label := gtk.NewLabel("Alle laufenden Jobs:")
	alignment.Add(label)
	vBox.PackStart(alignment, false, false, 0)

	list := gtk.NewListStore(glib.G_TYPE_STRING)

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter,
		0, "test")

	vBox.Add(tree)

	return vBox
}
