package Status

import (
	"github.com/mattn/go-gtk/gtk"
)

type StatusFrameUI struct {
	Box *gtk.VBox
	//	labelPanedValues   *gtk.VBox // Use later (maybe?)
	labelPaned         *gtk.HPaned
	labelCurrentFile   *gtk.Label
	labelAmountFiles   *gtk.Label
	labelElapsedTime   *gtk.Label
	labelRemainingTime *gtk.Label
}

// newStatusFrameUI creates a new UI object with the window including all controls.
func newStatusFrameUI() *StatusFrameUI {
	frame := &StatusFrameUI{}
	frame.createFrame()
	return frame
}

// createFrame creates the window with all controls.
func (frame *StatusFrameUI) createFrame() {
	frame.Box = gtk.NewVBox(false, 0)

	frame.Box.PackStart(frame.createLabelArea(), false, false, 0)
	frame.Box.PackStart(frame.createLogArea(), false, false, 0)
}

// createLabelArea creates the area with the labels that show e.g. the elapsed time.
func (frame *StatusFrameUI) createLabelArea() *gtk.Alignment {
	labelPaned := gtk.NewHPaned()

	// ------------------------------
	// CREATE LABEL AREAS
	// ------------------------------
	labelPaned.Pack1(frame.createDescriptionLabels(), false, false)
	labelPaned.Add(frame.createValueLabels())

	// ------------------------------
	// ALIGN AREA
	// ------------------------------
	alignment := gtk.NewAlignment(0, 0, 1, 0) // they won't be shrinked
	alignment.Add(labelPaned)

	return alignment
}

// createDescriptionLabels creates the left part of the label area.
// These labes just describe the value on the right.
func (frame *StatusFrameUI) createDescriptionLabels() *gtk.VBox {
	// ------------------------------
	// CREATE VBOX
	// ------------------------------
	panel := gtk.NewVBox(false, 3)
	panel.SetBorderWidth(10)
	panel.SetSizeRequest(-1, -1)

	// ------------------------------
	// ADD DESCRIPTION LABELS
	// ------------------------------
	panel.Add(frame.createLeftAlignedLabel("Current file:"))
	panel.Add(frame.createLeftAlignedLabel("Amount of files:"))
	panel.Add(frame.createLeftAlignedLabel("Elapsed time:"))
	panel.Add(frame.createLeftAlignedLabel("Remained time:"))

	return panel
}

// createValueLabels creates all the labels that contains the value (e.g. elapsed time).
func (frame *StatusFrameUI) createValueLabels() *gtk.VBox {
	// ------------------------------
	// CREATE VBOX
	// ------------------------------
	panel := gtk.NewVBox(false, 3)
	panel.SetBorderWidth(10)

	// ------------------------------
	// ADD VALUE LABELS
	// ------------------------------
	panel.Add(frame.createLeftAlignedLabel("/home/max/dummy/dir/with/very/long/path name/and/file.txt"))
	panel.Add(frame.createLeftAlignedLabel("420/1337"))
	panel.Add(frame.createLeftAlignedLabel("1:03:45"))
	panel.Add(frame.createLeftAlignedLabel("50:33"))

	return panel
}

// createLeftAlignedLabel creates a label that's aligned to the left side.
func (frame *StatusFrameUI) createLeftAlignedLabel(text string) *gtk.Label {
	label := gtk.NewLabel(text)
	label.SetAlignment(0, 0)
	return label
}

// createLogArea creates the area below all labels and shows all event outputs.
func (frame *StatusFrameUI) createLogArea() *gtk.Alignment {
	alignment := gtk.NewAlignment(0, 0, 1, 0)

	// ------------------------------
	// CREATE LOG
	// ------------------------------
	// TODO create real log-area (not just the dummy label)
	panel := gtk.NewHBox(false, 0)
	panel.Add(gtk.NewLabel("Dummy log"))

	alignment.Add(panel)

	return alignment
}
