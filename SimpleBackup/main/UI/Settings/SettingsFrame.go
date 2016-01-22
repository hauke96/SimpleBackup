package Settings

type SettingsFrame struct {
	settingsFrameUI *SettingsFrameUI
}

// NewSettingsFrame creates a window that contains all available settings
func NewSettingsFrame() *SettingsFrame {
	frame := SettingsFrame{settingsFrameUI: NewSettingsFrameUI()}
	return &frame
}

// ShowAndRun shows the window and starts the gtk-event routine.
func (frame *SettingsFrame) ShowAndRun() {
	frame.settingsFrameUI.window.ShowAll()
}
