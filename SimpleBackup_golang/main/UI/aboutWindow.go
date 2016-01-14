package UI

import (
	"github.com/mattn/go-gtk/gdk"
	"github.com/mattn/go-gtk/gtk"
)

// openAboutWindow creates a small window with all about-information.
func openAboutWindow() {
	// ------------------------------
	// WINDOW INIT
	// ------------------------------
	popup := gtk.NewWindow(gtk.WINDOW_TOPLEVEL)
	popup.SetTypeHint(gdk.WINDOW_TYPE_HINT_MENU)
	popup.SetResizable(false)
	popup.SetTitle("Nothing here :(")
	popup.SetSizeRequest(450, 150)
	paned := gtk.NewLayout(nil, nil)

	// ------------------------------
	// CONTENT PUT
	// ------------------------------
	paned.Put(gtk.NewLabel("N0thing's here yet :(\n\nIn the end this window will show some 'about' information.\n\n"), 10, 10)

	// ------------------------------
	// OK-BUTTON
	// ------------------------------
	button := gtk.NewButtonWithLabel("OK")
	buttonWidth := 100
	button.SetSizeRequest(buttonWidth, 25)
	button.Connect("button-press-event", func() { popup.Destroy() })

	// ------------------------------
	// SIZE CHANGE
	// ------------------------------
	var width int
	var height int
	popup.GetSize(&width, &height)
	paned.Put(button, width/2-buttonWidth/2, height-35)

	// ------------------------------
	// ADDING CONTROLS
	// ------------------------------
	popup.Add(paned)
	popup.ShowAll()
}
