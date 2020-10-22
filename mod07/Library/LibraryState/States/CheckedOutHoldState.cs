using System;

namespace LibraryState.States
{
    public class CheckedOutHoldState: BookState
    {
        public override BookState CheckIn()
        {
            return OnHoldBookState;
        }

        public override BookState CheckOut()
        {
            throw new InvalidOperationException("A checked out book cannot be checked out.");
        }

        public override BookState PlaceHold()
        {
            throw new InvalidOperationException("A checked out book that is already on hold cannot be placed on hold.");
        }
    }
}