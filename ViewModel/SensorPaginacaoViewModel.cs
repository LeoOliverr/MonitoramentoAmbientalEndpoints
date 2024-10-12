namespace MonitoramentoAmbientalEndpoints.ViewModel
{
    public class SensorPaginacaoViewModel
    {
        public IEnumerable<SensorViewModel> Sensors { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage => Sensors.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Sensor?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Sensor?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";
    }
}