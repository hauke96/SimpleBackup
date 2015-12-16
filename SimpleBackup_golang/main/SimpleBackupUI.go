package main

import (
	"fmt"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type MainUI struct {
	_window *gtk.Window
}

// Finish starts the UI process. This will enable clicks and GUI-stuff.
// Note that this functions will call the main loop of the ui, meaning that
// this will cause an (endless) loop.
// This function will also show the window.
func (ui MainUI) Finish() {
	if ui._window == nil {
		fmt.Errorf("Window of MainUI is nil!")
	} else {
		ui._window.ShowAll()
	}
	gtk.Main()
}

// NewMainUI creates a new UI.
func NewMainUI() MainUI {
	gtk.Init(nil)
	mainUI := MainUI{}
	mainUI._window = createMainWindow()
	return mainUI
}

// createMainWindow creates the main window :o
// This function won't show or enable anything, this is the job of the
// MainUI.MainUI_Finish function.
func createMainWindow() *gtk.Window {
	window := gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	window.SetTitle("Simple Backup Tool - golang version - ver.0.0.1 (alpha)")
	window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println("got destroy!", ctx.Data().(string))
		gtk.MainQuit()
	}, "foo")
	return window
}
