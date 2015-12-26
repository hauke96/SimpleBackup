package main

import (
	"fmt"
	"github.com/mattn/go-gtk/gdk"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type MainUI struct {
	_defaultBackgroundColor *gdk.Color
	_window                 *gtk.Window
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
	mainUI._defaultBackgroundColor = gdk.NewColorRGB(200, 200, 200)
	mainUI.createMainWindow()
	return mainUI
}

// createMainWindow creates the main window :o
// This function won't show or enable anything, this is the job of the
// MainUI.MainUI_Finish function.
func (ui *MainUI) createMainWindow() {
	ui._window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui._window.SetTitle("Simple Backup Tool - golang version - ver.0.0.1 (alpha)")
	ui._window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println("got destroy!", ctx.Data().(string))
		gtk.MainQuit()
	}, "foo")
	ui._window.Resize(800, 600)

	layout := gtk.NewLayout(nil, nil)
	layout.ModifyBG(gtk.STATE_NORMAL, ui._defaultBackgroundColor)

	ui.createMenuBar(layout)

	ui._window.Add(layout)

}

func (ui *MainUI) createMenuBar(layout *gtk.Layout) {
	menubar := gtk.NewMenuBar()
	menubar.ModifyBG(gtk.STATE_NORMAL, ui._defaultBackgroundColor)

	//--------------------------------------------------------
	// GtkMenuItem "File"
	//--------------------------------------------------------
	cascademenu := gtk.NewMenuItemWithMnemonic("_File")
	menubar.Append(cascademenu)
	submenu := gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	//--------------------------------------------------------
	// GtkMenuItem "Exit"
	//--------------------------------------------------------
	var menuitem *gtk.MenuItem
	menuitem = gtk.NewMenuItemWithMnemonic("E_xit")
	menuitem.Connect("activate", func() {
		gtk.MainQuit()
	})
	submenu.Append(menuitem)

	//--------------------------------------------------------
	// GtkMenuItem "View"
	//--------------------------------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_View")
	menubar.Append(cascademenu)
	submenu = gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	//--------------------------------------------------------
	// GtkMenuItem "Disable"
	//--------------------------------------------------------
	checkmenuitem := gtk.NewCheckMenuItemWithMnemonic("_Disable")
	checkmenuitem.Connect("activate", func() {
		fmt.Println("NewState: ", !checkmenuitem.GetActive())
	})
	submenu.Append(checkmenuitem)

	//--------------------------------------------------------
	// GtkMenuItem "Help"
	//--------------------------------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_Help")
	cascademenu.Connect("activate", func() {
		popup := gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
		popup.SetTypeHint(gdk.WINDOW_TYPE_HINT_MENU)
		popup.SetResizable(false)
		popup.SetTitle("Nothing here :(")
		popup.SetSizeRequest(450, 150)
		paned := gtk.NewLayout(nil, nil)

		paned.Put(gtk.NewLabel("N0thing's here yet :(\n\nIn the end this window will show some 'about' information.\n\n"), 10, 10)

		button := gtk.NewButtonWithLabel("OK")
		buttonWidth := 100
		button.SetSizeRequest(buttonWidth, 25)
		button.Connect("button-press-event", func() { popup.Destroy() })
		var width int
		var height int
		popup.GetSize(&width, &height)
		paned.Put(button, width/2-buttonWidth/2, height-35)

		popup.Add(paned)
		popup.ShowAll()
	})
	menubar.Append(cascademenu)

	layout.Add(menubar)
}
