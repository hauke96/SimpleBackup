package Settings

type SettingsFrame struct {
	_settingsFrameUI *SettingsFrameUI
}

func NewSettingsFrame() *SettingsFrame {
	frame := SettingsFrame{_settingsFrameUI: NewSettingsFrameUI()}
	return &frame
}

func (frame *SettingsFrame) ShowAndRun() {
	frame._settingsFrameUI._window.ShowAll()
}
