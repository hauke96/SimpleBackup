package UI

import (
	"./Backup"
	"./Settings"
	"./Status"
	"fmt"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type MainFrameUI struct {
	window *gtk.Window
	backup *Backup.BackupFrame
	status *Status.StatusFrame
}

// NewMainUI creates a new UI.
func NewMainFrameUI() MainFrameUI {
	gtk.Init(nil)
	mainUI := MainFrameUI{}
	mainUI.createMainFrameUIWindow()
	return mainUI
}

// Finish starts the UI process. This will enable clicks and GUI-stuff.
// Note that this functions will call the main loop of the ui, meaning that
// this will cause an (endless) loop.
// This function will also show the window.
func (ui *MainFrameUI) ShowAndRun() {
	if ui.window == nil {
		fmt.Errorf("Window of MainUI is nil!")
	} else {
		ui.window.ShowAll()
	}
	gtk.Main()
}

// createMainWindow creates the main window :o
// This function won't show or enable anything, this is the job of the
// MainUI.MainUIFinish function.
func (ui *MainFrameUI) createMainFrameUIWindow() {
	// ------------------------------
	// CREATE WINDOW
	// ------------------------------
	ui.window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui.window.SetTitle("Simple Backup Tool - golang version (0.1-indev)")
	ui.window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println(ctx.Data().(string))
		gtk.MainQuit()
	}, "Closing MainUI")
	ui.window.Resize(1300, 700)

	// ------------------------------
	// BOX AND PANED SET-UP
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)
	vPaned := gtk.NewVPaned()
	width, height := 0, 0
	ui.window.GetSize(&width, &height)
	vPaned.SetPosition(height / 3)

	// ------------------------------
	// CREATE SUB-UI STUFF
	// ------------------------------

	vBox.PackStart(ui.createMenuBar(), false, false, 0)

	vPaned.Pack1(ui.createBackupUI(), false, false)

	//TODO create own UI for label area

	vPaned.Add(ui.createStatusUI()) //TODO change to logUI

	// ------------------------------
	// ADD THINGS TO WINDOW
	// ------------------------------
	vBox.Add(vPaned)
	ui.window.Add(vBox)
}

func (ui *MainFrameUI) createMenuBar() *gtk.MenuBar {
	menubar := gtk.NewMenuBar()

	// ------------------------------
	// GtkMenuItem "File"
	// ------------------------------
	cascademenu := gtk.NewMenuItemWithMnemonic("File")
	menubar.Append(cascademenu)
	submenu := gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// GtkMenuItem "Exit"
	// ------------------------------
	var menuitem *gtk.MenuItem
	menuitem = gtk.NewMenuItemWithMnemonic("Exit")
	menuitem.Connect("activate", func() {
		gtk.MainQuit()
	})
	submenu.Append(menuitem)

	// ------------------------------
	// GtkMenuItem "View"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("View")
	menubar.Append(cascademenu)
	submenu = gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// GtkMenuItem SubItems is "View"
	// ------------------------------
	checkmenuitem := gtk.NewCheckMenuItemWithMnemonic("Settings")
	checkmenuitem.Connect("activate", func() {
		settingsWindow := Settings.NewSettingsFrame()
		settingsWindow.ShowAndRun()
	})
	submenu.Append(checkmenuitem)
	menuitem = gtk.NewMenuItemWithMnemonic("test1")
	submenu.Append(menuitem)
	menuitem = gtk.NewMenuItemWithMnemonic("test2")
	submenu.Append(menuitem)
	menuitem = gtk.NewMenuItemWithMnemonic("test3")
	submenu.Append(menuitem)
	menuitem = gtk.NewMenuItemWithMnemonic("test4")
	submenu.Append(menuitem)

	// ------------------------------
	// GtkMenuItem "Help"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("Help")
	cascademenu.Connect("activate", openAboutWindow)
	menubar.Append(cascademenu)

	return menubar
}

func (ui *MainFrameUI) createBackupUI() *gtk.HBox {
	ui.backup = Backup.NewBackupFrame()
	return ui.backup.BackupFrameUI.Box
}

func (ui *MainFrameUI) createStatusUI() *gtk.VPaned {
	ui.status = Status.NewStatusFrame()
	return ui.status.StatusFrameUI.Box
}
