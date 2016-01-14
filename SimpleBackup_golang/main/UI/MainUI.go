package UI

import (
	"fmt"
	"github.com/mattn/go-gtk/gdk"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

type MainUI struct {
	_defaultBackgroundColor *gdk.Color
	_window                 *gtk.Window
	_backupUI               *BackupUI
}

// Finish starts the UI process. This will enable clicks and GUI-stuff.
// Note that this functions will call the main loop of the ui, meaning that
// this will cause an (endless) loop.
// This function will also show the window.
func (ui MainUI) ShowAndRun() {
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
	mainUI._defaultBackgroundColor = gdk.NewColorRGB(200, 200, 203)
	mainUI.createMainUIWindow()
	return mainUI
}

// createMainWindow creates the main window :o
// This function won't show or enable anything, this is the job of the
// MainUI.MainUI_Finish function.
func (ui *MainUI) createMainUIWindow() {
	// ------------------------------
	// CREATE WINDOW
	// ------------------------------
	ui._window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui._window.SetTitle("Simple Backup Tool - golang version - ver.0.0.1 (alpha)")
	ui._window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println(ctx.Data().(string))
		gtk.MainQuit()
	}, "Closing MainUI")
	ui._window.ModifyBG(gtk.STATE_NORMAL, ui._defaultBackgroundColor)
	ui._window.Resize(1300, 850)

	// ------------------------------
	// WINDOW SET-UP
	// ------------------------------
	vBox := gtk.NewVBox(false, 1)
	vPaned := gtk.NewVPaned()
	vPaned.SetPosition(250)

	// ------------------------------
	// CREATE SUB-UI STUFF
	// ------------------------------

	vBox.PackStart(ui.createMenuBar(vBox), false, false, 0)

	vPaned.Add(ui.createBackupUI())

	vPaned.Add(ui.createEventUI())

	// ------------------------------
	// ADD THINGS TO WINDOW
	// ------------------------------
	vBox.Add(vPaned)
	ui._window.Add(vBox)
}

func (ui *MainUI) createMenuBar(vBox *gtk.VBox) *gtk.MenuBar {
	menubar := gtk.NewMenuBar()
	menubar.ModifyBG(gtk.STATE_NORMAL, ui._defaultBackgroundColor)

	// ------------------------------
	// GtkMenuItem "File"
	// ------------------------------
	cascademenu := gtk.NewMenuItemWithMnemonic("_File")
	menubar.Append(cascademenu)
	submenu := gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// GtkMenuItem "Exit"
	// ------------------------------
	var menuitem *gtk.MenuItem
	menuitem = gtk.NewMenuItemWithMnemonic("E_xit")
	menuitem.Connect("activate", func() {
		gtk.MainQuit()
	})
	submenu.Append(menuitem)

	// ------------------------------
	// GtkMenuItem "View"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_View")
	menubar.Append(cascademenu)
	submenu = gtk.NewMenu()
	cascademenu.SetSubmenu(submenu)

	// ------------------------------
	// GtkMenuItem "Disable"
	// ------------------------------
	checkmenuitem := gtk.NewCheckMenuItemWithMnemonic("_Disable")
	checkmenuitem.Connect("activate", func() {
		fmt.Println("NewState: ", !checkmenuitem.GetActive())
	})
	submenu.Append(checkmenuitem)

	// ------------------------------
	// GtkMenuItem "Help"
	// ------------------------------
	cascademenu = gtk.NewMenuItemWithMnemonic("_Help")
	cascademenu.Connect("activate", openAboutWindow)
	menubar.Append(cascademenu)

	return menubar
}

func (ui *MainUI) createBackupUI() *gtk.HBox {
	ui._backupUI = NewBackupUI()
	return ui._backupUI._box
}

func (ui *MainUI) createEventUI() *gtk.VBox {
	// TODO create real event ui
	box := gtk.NewVBox(false, 10)
	box.Add(gtk.NewLabel("Dummy-EventUI"))
	return box
}
