namespace UI
{
    public interface IProgressLine
    {
        void Close();
        void SetProgress(float progress);
        void Show();
    }
}