package UI

import (
	"C"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type BackupFrameUI struct {
	_box         *gtk.HBox
	_backupList  *gtk.ListStore
	_runningList *gtk.ListStore
	_newJob,
	_editJob,
	_removeJob,
	_startJob,
	_pauseJob,
	_stopJob *gtk.Button
}

// NewBackupUI initiates the backup ui and creates all control.
func NewBackupUI() *BackupFrameUI {
	backupUI := BackupFrameUI{}
	backupUI.createBackupUIPanel()
	return &backupUI
}

// createBackupUIPanel is the main function in createing the backupUI stuff.
func (backupUI *BackupFrameUI) createBackupUIPanel() {
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
func (backupUI *BackupFrameUI) createBackupList() *gtk.VBox {
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
	backupUI._backupList = list

	tree := gtk.NewTreeView()
	tree.SetModel(list)
	tree.AppendColumn(gtk.NewTreeViewColumnWithAttributes("", gtk.NewCellRendererText(), "text", 0))
	tree.SetHeadersVisible(false)

	var iter gtk.TreeIter
	list.Append(&iter)
	list.SetValue(&iter,
		0, " hallo hallo hallo hallo hallo hallo")
	list.Append(&iter)
	list.SetValue(&iter,
		0, "ololol")

	// ------------------------------
	// ADDING AND RETURNING
	// ------------------------------
	vBox.Add(tree)
	vBox.SetSizeRequest(0, 0)

	return vBox
}

// createBackupButtonArea creates the middle part with the buttons.
func (backupUI *BackupFrameUI) createButtonArea() *gtk.VBox {
	// ------------------------------
	// VBOX INITIATING
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)
	vBox.SetSizeRequest(100, -1)

	// ------------------------------
	// CREATE BUTTONS
	// ------------------------------
	backupUI.newJobButton("Job erstellen", vBox, backupUI._newJob)
	backupUI.newJobButton("Job editieren", vBox, backupUI._editJob)
	backupUI.newJobButton("Job löschen", vBox, backupUI._removeJob)

	backupUI.newJobButton("Starten", vBox, backupUI._startJob)
	backupUI.newJobButton("Pausieren", vBox, backupUI._pauseJob)
	backupUI.newJobButton("Stoppen", vBox, backupUI._stopJob)

	return vBox
}

// newJobButton creates a new button for the middle panel.
func (backupUI *BackupFrameUI) newJobButton(text string, vBox *gtk.VBox, button *gtk.Button) {
	button = gtk.NewButtonWithLabel(text)
	button.SetSizeRequest(100, 23)
	vBox.Add(button)
}

// createRunningList creates a list like the createBakupList but there'll be
// only running backups here.
func (backupUI *BackupFrameUI) createRunningList() *gtk.VBox {
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
	backupUI._runningList = list

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
