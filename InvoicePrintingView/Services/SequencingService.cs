using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace InvoiceViewModel
{
    public static class SequencingService
    {
        public static ObservableCollection<T> SetCollectionSequence<T>(ObservableCollection<T> targetCollection) where T : ISequencedObject
        {
            // Initialize
            var sequenceNumber = 1;

            // Resequence
            foreach (ISequencedObject sequencedObject in targetCollection)
            {
                sequencedObject.SequenceNumber = sequenceNumber;
                sequenceNumber++;
            }

            // Set return value
            return targetCollection;
        }
    }
}
