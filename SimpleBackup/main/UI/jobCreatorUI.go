package UI

import (
	"fmt"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type jobCreatorUI struct {
	window *gtk.Window
}

func NewJobCreatorUI() {
	jobCreatorUI := jobCreatorUI{}
	jobCreatorUI.createJobCreatorUIWindow()
	return
}

func (ui *jobCreatorUI) createJobCreatorUIWindow() {
	ui.window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui.window.SetTitle("Create Job")
	ui.window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println(ctx.Data().(string))
		gtk.MainQuit()
	}, "Closing MainUI")

	ui.window.ShowAll()
}
