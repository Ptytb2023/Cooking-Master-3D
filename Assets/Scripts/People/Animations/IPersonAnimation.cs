namespace People.Animations
{
    public interface IPersonAnimation
    {
        void PlayIdel();
        void PlayMove(bool isMove);
    }
}