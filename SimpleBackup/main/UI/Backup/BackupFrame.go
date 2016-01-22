package Backup

type BackupFrame struct {
	BackupFrameUI *BackupFrameUI
}

// NewBackupFrame creates the frame that contains the backup lists and buttons.
func NewBackupFrame() *BackupFrame {
	frame := BackupFrame{BackupFrameUI: NewBackupFrameUI()}
	return &frame
}
