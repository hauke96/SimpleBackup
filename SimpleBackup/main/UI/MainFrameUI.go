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
	vPaned.Add(ui.createStatusUI())

	// ------------------------------
	// ADD THINGS TO WINDOW
	// ------------------------------
	vBox.Add(vPaned)
	ui.window.Add(vBox)
}

func (ui *MainFrameUI) createMenuBar() *gtk.MenuBar {
	menubar := gtk.NewMenuBar()

	// ------------------------------
	// MENU ITEM "File"
	// ------------------------------
	cascademenu := gtk.NewMenuItemWithMnemonic("_File")
	menubar.Append(cascademenu)
	submenu := gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// MENU ITEM  "Exit"
	// ------------------------------
	var menuitem *gtk.MenuItem
	menuitem = gtk.NewMenuItemWithMnemonic("_Exit")
	menuitem.Connect("activate", func() {
		gtk.MainQuit()
	})
	submenu.Append(menuitem)

	// ------------------------------
	// MENU ITEM  "View"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_View")
	menubar.Append(cascademenu)
	submenu = gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// SUB MENU "Settings"
	// ------------------------------
	checkmenuitem := gtk.NewCheckMenuItemWithMnemonic("_Settings")
	checkmenuitem.Connect("activate", func() {
		settingsWindow := Settings.NewSettingsFrame()
		settingsWindow.ShowAndRun()
	})

	// ------------------------------
	// DUMMY ENTRIES
	// ------------------------------
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
	// MENU ITEM  "Help"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_Help")
	submenu = gtk.NewMenu()
	menubar.Append(cascademenu)

	// ------------------------------
	// SUB MENU "About"
	// ------------------------------
	menuitem = gtk.NewMenuItemWithMnemonic("_About")
	menuitem.Connect("activate", openAboutWindow)
	submenu.Add(menuitem)
	cascademenu.SetSubmenu(submenu)

	return menubar
}

// createBackupUI creates the BackupUI and gets its widget.
func (ui *MainFrameUI) createBackupUI() *gtk.Alignment {
	ui.backup = Backup.NewBackupFrame()
	return ui.backup.BackupFrameUI.Box
}

// createBackupUI creates the StatusUI and gets its widget.
func (ui *MainFrameUI) createStatusUI() *gtk.VBox {
	ui.status = Status.NewStatusFrame()
	return ui.status.StatusFrameUI.Box
}
