namespace LibraryState.States
{
    public abstract class BookState
    {
        public static BookState CheckedInBookState { get; } = new CheckedInState();
        public static BookState CheckedOutBookState { get; } = new CheckedOutState();
        public static BookState CheckedOutHoldBookState { get; } = new CheckedOutHoldState();
        public static BookState OnHoldBookState { get; } = new OnHoldState();

        public abstract BookState CheckIn();
        public abstract BookState CheckOut();
        public abstract BookState PlaceHold();
    }
}