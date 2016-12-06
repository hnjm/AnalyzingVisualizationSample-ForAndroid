using Android.Content;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Android;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;

namespace AnalyzingVisualization
{
    public class HeatStyleSample : BaseSample
    {
        public HeatStyleSample(Context context)
            : base(context)
        { }

        protected override void InitializeMap()
        {
            MapView.MapUnit = GeographyUnit.DecimalDegree;
            MapView.CurrentExtent = new RectangleShape(-124.097208477811, 48.9471097666172, -110.242106301448, 28.7359794668483);

            ShapeFileFeatureLayer usEarthquakeLayer = new ShapeFileFeatureLayer(SampleHelper.GetDataPath("usEarthquake_Simplified.shp"));
            LayerOverlay layerOverlay = new LayerOverlay();
            layerOverlay.Layers.Add(usEarthquakeLayer);
            MapView.Overlays.Add(layerOverlay);

            usEarthquakeLayer.ZoomLevelSet.ZoomLevel01.CustomStyles.Clear();
            usEarthquakeLayer.ZoomLevelSet.ZoomLevel01.CustomStyles.Add(new HeatStyle(10, 150, "MAGNITUDE", 0, 12, 100, DistanceUnit.Kilometer));
            usEarthquakeLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
        }
    }
}