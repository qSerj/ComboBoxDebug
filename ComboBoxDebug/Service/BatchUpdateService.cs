namespace ComboBoxDebug.Service;

using System;

public class BatchUpdateService
{
    private int _batchLevel = 0;
    public bool IsBatch => _batchLevel > 0;

    public IDisposable BeginBatch()
    {
        _batchLevel++;
        return new BatchScope(this);
    }

    private void EndBatch()
    {
        _batchLevel--;
    }

    private class BatchScope : IDisposable
    {
        private BatchUpdateService _svc;
        public BatchScope(BatchUpdateService svc) { _svc = svc; }
        public void Dispose() { _svc.EndBatch(); }
    }
}