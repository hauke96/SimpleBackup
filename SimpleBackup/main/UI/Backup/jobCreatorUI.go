package Backup

import (
	"fmt"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type jobCreatorUI struct {
	window *gtk.Window
}

func NewJobCreatorUI() *jobCreatorUI {
	jobCreatorUI := jobCreatorUI{}
	jobCreatorUI.createJobCreatorUIWindow()
	return &jobCreatorUI
}

func (ui *jobCreatorUI) createJobCreatorUIWindow() {
	ui.window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui.window.SetModal(true)
	ui.window.SetTitle("Create Job")
	ui.window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println(ctx.Data().(string))
		gtk.MainQuit()
	}, "Closing jobCreatorUI")

	ui.window.ShowAll()
}

// ShowAndRun shows the window and starts the gtk-event routine.
func (ui *jobCreatorUI) ShowAndRun() {
	if ui.window == nil {
		fmt.Errorf("Window of jobCreatorUI is nil!")
	} else {
		ui.window.ShowAll()
	}
	gtk.Main()
}
