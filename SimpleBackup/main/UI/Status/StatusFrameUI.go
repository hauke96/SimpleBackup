package Status

import (
	"github.com/mattn/go-gtk/gtk"
)

type StatusFrameUI struct {
	Box                *gtk.VPaned
	labelPanedValues   *gtk.VBox
	labelPaned         *gtk.HPaned
	labelCurrentFile   *gtk.Label
	labelAmountFiles   *gtk.Label
	labelElapsedTime   *gtk.Label
	labelRemainingTime *gtk.Label
}

func newStatusFrameUI() *StatusFrameUI {
	frame := &StatusFrameUI{}
	frame.createFrame()
	return frame
}

func (frame *StatusFrameUI) createFrame() {
	frame.Box = gtk.NewVPaned()
	frame.Box.SetBorderWidth(10)

	frame.Box.Pack1(frame.createLabelArea(), false, false)
	frame.Box.Add(frame.createLogArea())
}

func (frame *StatusFrameUI) createLabelArea() *gtk.Alignment {
	labelPaned := gtk.NewHPaned()

	labelPaned.Add(frame.createDescriptionLabel())
	labelPaned.Add(frame.createValueLabel())

	alignment := gtk.NewAlignment(0, 0, 1, 0)
	alignment.Add(labelPaned)

	return alignment
}

func (frame *StatusFrameUI) createDescriptionLabel() *gtk.VBox {
	panel := gtk.NewVBox(false, 0)
	panel.SetSizeRequest(150, -1)

	panel.Add(createLeftAlignesLabel("Current file:"))
	panel.Add(createLeftAlignesLabel("Amount of files:"))
	panel.Add(createLeftAlignesLabel("Elapsed time:"))
	panel.Add(createLeftAlignesLabel("Remained time:"))

	return panel
}

func (frame *StatusFrameUI) createValueLabel() *gtk.VBox {
	panel := gtk.NewVBox(false, 0)

	panel.Add(createLeftAlignesLabel("/home/max/dummy/dir/with/very/long/path name/and/file.txt"))
	panel.Add(createLeftAlignesLabel("420/1337"))
	panel.Add(createLeftAlignesLabel("1:03:45"))
	panel.Add(createLeftAlignesLabel("50:33"))

	return panel
}

func createLeftAlignesLabel(text string) *gtk.Label {
	label := gtk.NewLabel(text)
	label.SetAlignment(0, 0)
	return label
}

func (frame *StatusFrameUI) createLogArea() *gtk.Alignment {
	alignment := gtk.NewAlignment(0, 0, 1, 0)

	panel := gtk.NewHBox(false, 0)
	panel.Add(gtk.NewLabel("Dummy log"))

	alignment.Add(panel)

	return alignment
}
