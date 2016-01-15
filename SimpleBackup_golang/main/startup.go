package main

import (
	"./UI"
	"fmt"
	"github.com/mattn/go-gtk/gtk"
)

// ------------------------------
//
// ------------------------------

func main() {
	gtk.RCParse("./styles/Mona/gtkrc")
	mainUI := UI.NewMainUI()
	mainUI.ShowAndRun()
	fmt.Println("Thanks for using SimpleBackup :)")
}
