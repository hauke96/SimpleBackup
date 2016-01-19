package UI

import (
	"fmt"
	"github.com/mattn/go-gtk/glib"
	"github.com/mattn/go-gtk/gtk"
)

// createMainWindow creates the main window :o
// This function won't show or enable anything, this is the job of the
// MainUI.MainUI_Finish function.
func (ui *MainFrameUI) createMainUIWindow() {
	// ------------------------------
	// CREATE WINDOW
	// ------------------------------
	ui._window = gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	ui._window.SetTitle("Simple Backup Tool - golang version - ver.0.0.1 (alpha)")
	ui._window.Connect("destroy", func(ctx *glib.CallbackContext) {
		fmt.Println(ctx.Data().(string))
		gtk.MainQuit()
	}, "Closing MainUI")
	ui._window.Resize(1300, 850)

	// ------------------------------
	// BOX AND PANED SET-UP
	// ------------------------------
	vBox := gtk.NewVBox(false, 10)
	vPaned := gtk.NewVPaned()
	width, height := 0, 0
	ui._window.GetSize(&width, &height)
	vPaned.SetPosition(height / 3)

	// ------------------------------
	// CREATE SUB-UI STUFF
	// ------------------------------

	vBox.PackStart(ui.createMenuBar(), false, false, 0)

	vPaned.Add(ui.createBackupUI())

	vPaned.Add(ui.createEventUI())

	// ------------------------------
	// ADD THINGS TO WINDOW
	// ------------------------------
	vBox.Add(vPaned)
	ui._window.Add(vBox)
}

func (ui *MainFrameUI) createMenuBar() *gtk.MenuBar {
	menubar := gtk.NewMenuBar()

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
	cascademenu = gtk.NewMenuItemWithMnemonic("_Help")
	cascademenu.Connect("activate", openAboutWindow)
	menubar.Append(cascademenu)

	return menubar
}

func (ui *MainFrameUI) createBackupUI() *gtk.HBox {
	ui._backupUI = NewBackupUI()
	return ui._backupUI._box
}

func (ui *MainFrameUI) createEventUI() *gtk.VBox {
	// TODO create real event ui
	box := gtk.NewVBox(false, 10)
	box.SetBorderWidth(10)
	label := gtk.NewLabel("Dummy-EventUI")
	box.Add(label)
	return box
}
