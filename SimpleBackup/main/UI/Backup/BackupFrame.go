package Backup

type BackupFrame struct {
	BackupFrameUI *BackupFrameUI
}

func NewBackupFrame() *BackupFrame {
	frame := BackupFrame{BackupFrameUI: NewBackupFrameUI()}
	return &frame
}
