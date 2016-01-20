package UI

import (
	"fmt"
	"github.com/mattn/go-gtk/gtk"
)

type MainFrameUI struct {
	_window   *gtk.Window
	_backupUI *BackupUI
}

// Finish starts the UI process. This will enable clicks and GUI-stuff.
// Note that this functions will call the main loop of the ui, meaning that
// this will cause an (endless) loop.
// This function will also show the window.
func (ui MainFrameUI) ShowAndRun() {
	if ui._window == nil {
		fmt.Errorf("Window of MainUI is nil!")
	} else {
		ui._window.ShowAll()
	}
	gtk.Main()
}

// NewMainUI creates a new UI.
func NewMainUI() MainFrameUI {
	gtk.Init(nil)
	mainUI := MainFrameUI{}
	mainUI.createMainUIWindow()
	return mainUI
}
