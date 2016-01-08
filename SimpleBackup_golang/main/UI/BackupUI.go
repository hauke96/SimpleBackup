package UI

import (
	"github.com/mattn/go-gtk/gtk"
)

type BackupUI struct {
	_panel *gtk.HPaned
}

func NewBackupUI() BackupUI {
	backupUI := BackupUI{}
	backupUI.createBackupUIPanel()
	return backupUI
}

func (backupUI *BackupUI) createBackupUIPanel() {
	//	rhPaned := gtk.NewHPaned()

	// create controls etc.
}
