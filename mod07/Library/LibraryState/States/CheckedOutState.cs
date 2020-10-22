using System;

namespace LibraryState.States
{
    public class CheckedOutState: BookState
    {
        public override BookState CheckIn()
        {
            return CheckedInBookState;
        }

        public override BookState CheckOut()
        {
            throw new InvalidOperationException("A checked out book cannot be checked out.");
        }

        public override BookState PlaceHold()
        {
            return CheckedOutHoldBookState;
        }
    }
}