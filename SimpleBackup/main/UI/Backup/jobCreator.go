package Backup

type jobCreator struct {
	jobCreatorUI *jobCreatorUI
}

func NewJobCreator() *jobCreator {
	ui := NewJobCreatorUI()
	jobCreatorUI := jobCreator{jobCreatorUI: ui}
	return &jobCreatorUI
}

// ShowAndRun shows the window and starts the gtk-event routine.
func (frame *jobCreator) ShowAndRun() {
	frame.jobCreatorUI.ShowAndRun()
}
