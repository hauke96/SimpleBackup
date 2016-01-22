package UI

import ()

type MainFrame struct {
	mainFrameUI *MainFrameUI
}

// NewMainFrame creates a window that contains the menubar, backup- and statusUI.
func NewMainFrame() *MainFrame {
	ui := NewMainFrameUI()
	mainFrame := MainFrame{mainFrameUI: &ui}
	return &mainFrame
}

// ShowAndRun shows the window and starts the gtk-event routine.
func (frame *MainFrame) ShowAndRun() {
	frame.mainFrameUI.ShowAndRun()
}
