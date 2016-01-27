package Settings

import (
	"fmt"
	"io/ioutil"
	"os"
	"text/tabwriter"
)

type ThemeChooser struct {
	themeChooserUI *ThemeChooserUI
}

func NewThemeChooser() *ThemeChooser {
	frame := ThemeChooser{themeChooserUI: NewThemeChooserUI()}
	frame.themeListLoad()
	return &frame
}

// loadThemeList reads all subdirectories in the "styles" dir and save the names in a list.
// If one of the directories has no "./styles/foo/gtkrc" file (where "foo" is the style name),
// there might be an error in parsing the style.
func (frame ThemeChooser) themeListLoad() {
	fmt.Println("Reading style directories...")

	// ------------------------------
	// INIT LIST FOR VALID THEME DIRs
	// ------------------------------
	validThemes := make([]string, 0)

	// ------------------------------
	// READ DIRS IN STYLE FOLDER
	// ------------------------------
	list, e := ioutil.ReadDir("./styles/")
	if e != nil {
		fmt.Println(fmt.Errorf(e.Error()))
		return
	}

	// ------------------------------
	// DETERMINE VALID THEMES
	// ------------------------------
	// "vlid" means: There's a gtkrc-file in the root dir of the theme

	// a tabwriter for more beautiful output
	writer := new(tabwriter.Writer)
	writer.Init(os.Stdout, 0, 4, 2, ' ', 0)
	defer writer.Flush()

	fmt.Println("Got following style directories: ")

	for _, v := range list {
		dir := v.Name()
		output := "./styles/" + dir + "\t"
		if _, err := os.Stat("styles/" + dir + "/gtkrc"); err == nil {
			output += "(valid)"
			validThemes = append(validThemes, dir)
		}
		fmt.Fprintln(writer, output)
	}

	// ------------------------------
	// SET THEME LIST
	// ------------------------------
	frame.themeChooserUI.themeList = validThemes
}
