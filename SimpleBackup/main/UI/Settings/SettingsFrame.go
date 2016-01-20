package Settings

type SettingsFrame struct {
	settingsFrameUI *SettingsFrameUI
}

func NewSettingsFrame() *SettingsFrame {
	frame := SettingsFrame{settingsFrameUI: NewSettingsFrameUI()}
	return &frame
}

func (frame *SettingsFrame) ShowAndRun() {
	frame.settingsFrameUI.window.ShowAll()
}
