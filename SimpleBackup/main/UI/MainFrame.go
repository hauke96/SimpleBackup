package UI

import ()

type MainFrame struct {
	mainFrameUI *MainFrameUI
}

func NewMainFrame() *MainFrame {
	ui := NewMainFrameUI()
	mainFrame := MainFrame{mainFrameUI: &ui}
	return &mainFrame
}

func (frame *MainFrame) ShowAndRun() {
	frame.mainFrameUI.ShowAndRun()
}
