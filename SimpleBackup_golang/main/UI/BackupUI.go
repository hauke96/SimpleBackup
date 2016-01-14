package UI

import (
	"C"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type BackupUI struct {
	_box *gtk.HBox
}

// NewBackupUI initiates the backup ui and creates all control.
func NewBackupUI() *BackupUI {
	backupUI := BackupUI{}
	backupUI.createBackupUIPanel()
	return &backupUI
}

// createBackupUIPanel is the main function in createing the backupUI stuff.
func (backupUI *BackupUI) createBackupUIPanel() {
	hBox := gtk.NewHBox(false, 10)
	hBox.SetBorderWidth(10)
	hBox.SetSizeRequest(100, 100)

	hBox.Add(backupUI.createBackupList())

	alignment := gtk.NewAlignment(0, 0.5, 0, 0)
	alignment.Add(backupUI.createButtonArea())
	hBox.PackStart(alignment, false, false, 0)

	hBox.Add(backupUI.createRunningList())

	backupUI._box = hBox
}

// createBackupList creates the left list with all backups.
func (backupUI *BackupUI) createBackupList() *gtk.VBox {
	// ------------------------------
	// VBOX INITIATING
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)

	// ------------------------------
	// LABEL
	// ------------------------------
	alignment := gtk.NewAlignment(0, 0, 0, 0)
	label := gtk.NewLabel("Alle Backup Jobs:")
	alignment.Add(label)
	vBox.PackStart(alignment, false, false, 0)

	// ------------------------------
	// LIST SET-UP
	// ------------------------------
	list := gtk.NewListStore(glib.G_TYPE_STRING)

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter,
		0, " hallo hallo hallo hallo hallo hallo")

	// ------------------------------
	// ADDING AND RETURNING
	// ------------------------------
	vBox.Add(tree)
	vBox.SetSizeRequest(0, 0)

	return vBox
}

// createBackupButtonArea creates the middle part with the buttons.
func (backupUI *BackupUI) createButtonArea() *gtk.VBox {
	// ------------------------------
	// VBOX INITIATING
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)
	vBox.SetSizeRequest(100, 100)

	// ------------------------------
	// CREATE BUTTONS
	// ------------------------------
	button1 := gtk.NewButtonWithLabel("Start Job0")
	vBox.Add(button1)
	button2 := gtk.NewButtonWithLabel("Start Job1")
	vBox.Add(button2)
	button3 := gtk.NewButtonWithLabel("Start Job2")
	vBox.Add(button3)

	return vBox
}

// createRunningList creates a list like the createBakupList but there'll be
// only running backups here.
func (backupUI *BackupUI) createRunningList() *gtk.VBox {
	// ------------------------------
	// VBOX INITIATING
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)

	// ------------------------------
	// LABEL
	// ------------------------------
	alignment := gtk.NewAlignment(0, 0, 0, 0)
	label := gtk.NewLabel("Alle laufenden Jobs:")
	alignment.Add(label)
	vBox.PackStart(alignment, false, false, 0)

	// ------------------------------
	// LIST SET-UP
	// ------------------------------
	list := gtk.NewListStore(glib.G_TYPE_STRING)

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter,
		0, "test")

	// ------------------------------
	// ADDING AND RETURNING
	// ------------------------------
	vBox.Add(tree)
	vBox.SetSizeRequest(0, 0)

	return vBox
}
