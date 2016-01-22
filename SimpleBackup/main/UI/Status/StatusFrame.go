package Status

type StatusFrame struct {
	StatusFrameUI *StatusFrameUI
}

// NewStatusFrame creates a frame that contains the labels and log output.
func NewStatusFrame() *StatusFrame {
	frame := newStatusFrameUI()
	return &StatusFrame{StatusFrameUI: frame}
}
