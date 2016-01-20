package UI

import ()

type MainFrame struct {
	_mainFrameUI *MainFrameUI
}

func NewMainFrame() *MainFrame {
	ui := NewMainFrameUI()
	mainFrame := MainFrame{_mainFrameUI: &ui}
	return &mainFrame
}

func (frame *MainFrame) ShowAndRun() {
	frame._mainFrameUI.ShowAndRun()
}
