package Status

type StatusFrame struct {
	StatusFrameUI *StatusFrameUI
}

func NewStatusFrame() *StatusFrame {
	frame := newStatusFrameUI()
	return &StatusFrame{StatusFrameUI: frame}
}
