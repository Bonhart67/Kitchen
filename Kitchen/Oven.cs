using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Interfaces;

namespace Kitchen.Kitchen
{
    public class Oven
    {
        private const int MAX_OVEN_SLOT = 4;
        private Queue<INeedsCooking> _toBeCooked;
        private IEnumerable<INeedsCooking> _ovenSlots;
        public Oven(IEnumerable<INeedsCooking> toBeCooked)
        {
            this._toBeCooked = new Queue<INeedsCooking>(toBeCooked);
            Task.Run(Cook);
        }

        private async Task Cook()
        {
            while (this._toBeCooked.Any())
            {
                this._ovenSlots = this._toBeCooked
                    .Take(MAX_OVEN_SLOT)
                    .TakeWhile(i => i.GetType().Equals(this._toBeCooked.GetType()));
                Task.WaitAll(this._ovenSlots.Select(i => i.Prepare()).ToArray());
                await Task.Delay(this._ovenSlots.First().CookingTime);
                for (int i = 0; i < this._ovenSlots.Count(); i++)
                {
                    this._ovenSlots.ElementAt(i).Cook();
                    this._toBeCooked.Dequeue();
                }
            }
        }
    }
}