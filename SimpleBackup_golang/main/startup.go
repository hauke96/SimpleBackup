package main

import (
	"./UI"
	"fmt"
)

func main() {
	mainUI := UI.NewMainUI()
	mainUI.ShowAndRun()
	fmt.Println("Thanks for using SimpleBackup :D")
}
