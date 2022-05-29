using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSLines : MonoBehaviour
{
    public static List<GPSLine> gpsLines = new List<GPSLine>();    

    // Start is called before the first frame update
    void Start()
    {
        AddGPSLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddGPSLines()
    {
        GPSLine g0 = new GPSLine();
        g0.StartX = 45.25192522f;
        g0.StartY = -74.30465933f;
        g0.EndX = 45.25217242f;
        g0.EndY = -74.30493051f;

        GPSLine g1 = new GPSLine();
        g1.StartX = 45.25217242f;
        g1.StartY = -74.30493051f;
        g1.EndX = 45.25223726f;
        g1.EndY = -74.30485862f;

        GPSLine g2 = new GPSLine();
        g2.StartX = 45.25223726f;
        g2.StartY = -74.30485862f;
        g2.EndX = 45.25216886f;
        g2.EndY = -74.30477276f;

        GPSLine g3 = new GPSLine();
        g3.StartX = 45.25216886f;
        g3.StartY = -74.30477276f;
        g3.EndX = 45.25233876f;
        g3.EndY = -74.30451992f;

        GPSLine g4 = new GPSLine();
        g4.StartX = 45.25233876f;
        g4.StartY = -74.30451992f;
        g4.EndX = 45.25239388f;
        g4.EndY = -74.30457803f;

        GPSLine g5 = new GPSLine();
        g5.StartX = 45.25239388f;
        g5.StartY = -74.30457803f;
        g5.EndX = 45.25256660f;
        g5.EndY = -74.30428198f;

        GPSLine g6 = new GPSLine();
        g6.StartX = 45.25256660f;
        g6.StartY = -74.30428198f;
        g6.EndX = 45.25251389f;
        g6.EndY = -74.30423680f;

        GPSLine g7 = new GPSLine();
        g7.StartX = 45.25251389f;
        g7.StartY = -74.30423680f;
        g7.EndX = 45.25245589f;
        g7.EndY = -74.30435882f;

        GPSLine g8 = new GPSLine();
        g8.StartX = 45.25245589f;
        g8.StartY = -74.30435882f;
        g8.EndX = 45.25227984f;
        g8.EndY = -74.30418895f;

        GPSLine g9 = new GPSLine();
        g9.StartX = 45.25227984f;
        g9.StartY = -74.30418895f;
        g9.EndX = 45.25221712f;
        g9.EndY = -74.30429170f;

        GPSLine g10 = new GPSLine();
        g10.StartX = 45.25219334f;
        g10.StartY = -74.30462339f;
        g10.EndX = 45.25218605f;
        g10.EndY = -74.30458429f;

        GPSLine g11 = new GPSLine();
        g11.StartX = 45.25218605f;
        g11.StartY = -74.30458429f;
        g11.EndX = 45.25220807f;
        g11.EndY = -74.30449879f;

        GPSLine g12 = new GPSLine();
        g12.StartX = 45.25218605f;
        g12.StartY = -74.30458429f;
        g12.EndX = 45.25220807f;
        g12.EndY = -74.30449879f;

        GPSLine g13 = new GPSLine();
        g13.StartX = 45.25220807f;
        g13.StartY = -74.30449879f;
        g13.EndX = 45.25212006f;
        g13.EndY = -74.30441624f;

        GPSLine g14 = new GPSLine();
        g14.StartX = 45.25202718f;
        g14.StartY = -74.30450763f;
        g14.EndX = 45.25213116f;
        g14.EndY = -74.30433164f;

        GPSLine g15 = new GPSLine();
        g15.StartX = 45.25202718f;
        g15.StartY = -74.30450763f;
        g15.EndX = 45.25215605f;
        g15.EndY = -74.30466252f;

        GPSLine g16 = new GPSLine();
        g16.StartX = 45.25213116f;
        g16.StartY = -74.30433164f;
        g16.EndX = 45.25223132f;
        g16.EndY = -74.30443279f;

        GPSLine g17 = new GPSLine();
        g17.StartX = 45.25223132f;
        g17.StartY = -74.30443279f;
        g17.EndX = 45.25248129f;
        g17.EndY = -74.30400094f;

        GPSLine g18 = new GPSLine();
        g18.StartX = 45.25248129f;
        g18.StartY = -74.30400094f;
        g18.EndX = 45.25239297f;
        g18.EndY = -74.30389968f;

        GPSLine g19 = new GPSLine();
        g19.StartX = 45.25239297f;
        g19.StartY = -74.30389968f;
        g19.EndX = 45.25256586f;
        g19.EndY = -74.30364954f;

        GPSLine g20 = new GPSLine();
        g20.StartX = 45.25256586f;
        g20.StartY = -74.30364954f;
        g20.EndX = 45.25269021f;
        g20.EndY = -74.30379933f;

        GPSLine g21 = new GPSLine();
        g21.StartX = 45.25271300f;
        g21.StartY = -74.30376009f;
        g21.EndX = 45.25265993f;
        g21.EndY = -74.30366070f;

        GPSLine g22 = new GPSLine();
        g22.StartX = 45.25265993f;
        g22.StartY = -74.30366070f;
        g22.EndX = 45.25274052f;
        g22.EndY = -74.30351548f;

        GPSLine g23 = new GPSLine();
        g23.StartX = 45.25274052f;
        g23.StartY = -74.30351548f;
        g23.EndX = 45.25283796f;
        g23.EndY = -74.30363989f;

        GPSLine g24 = new GPSLine();
        g24.StartX = 45.25243758f;
        g24.StartY = -74.30423245f;
        g24.EndX = 45.25271041f;
        g24.EndY = -74.30374639f;

        GPSLine g25 = new GPSLine();
        g25.StartX = 45.25246282f;
        g25.StartY = -74.30425461f;
        g25.EndX = 45.25255572f;
        g25.EndY = -74.30411663f;

        GPSLine g26 = new GPSLine();
        g26.StartX = 45.25255572f;
        g26.StartY = -74.30411663f;
        g26.EndX = 45.25264383f;
        g26.EndY = -74.30424406f;

        GPSLine g27 = new GPSLine();
        g27.StartX = 45.25264383f;
        g27.StartY = -74.30424406f;
        g27.EndX = 45.25281759f;
        g27.EndY = -74.30393690f;

        GPSLine g28 = new GPSLine();
        g28.StartX = 45.25281759f;
        g28.StartY = -74.30393690f;
        g28.EndX = 45.25273295f;
        g28.EndY = -74.30384213f;

        GPSLine g29 = new GPSLine();
        g29.StartX = 45.25273295f;
        g29.StartY = -74.30384213f;
        g29.EndX = 45.25265138f;
        g29.EndY = -74.30395189f;

        GPSLine g30 = new GPSLine();
        g30.StartX = 45.25277969f;
        g30.StartY = -74.30391441f;
        g30.EndX = 45.25283001f;
        g30.EndY = -74.30381285f;

        GPSLine g31 = new GPSLine();
        g31.StartX = 45.25283001f;
        g31.StartY = -74.30381285f;
        g31.EndX = 45.25277665f;
        g31.EndY = -74.30375738f;

        GPSLine g32 = new GPSLine();
        g32.StartX = 45.25277665f;
        g32.StartY = -74.30375738f;
        g32.EndX = 45.25293858f;
        g32.EndY = -74.30350039f;

        GPSLine g33 = new GPSLine();
        g33.StartX = 45.25293858f;
        g33.StartY = -74.30350039f;
        g33.EndX = 45.25280911f;
        g33.EndY = -74.30342222f;

        GPSLine g34 = new GPSLine();
        g34.StartX = 45.25292257f;
        g34.StartY = -74.30334023f;
        g34.EndX = 45.25245541f;
        g34.EndY = -74.30280293f;

        GPSLine g35 = new GPSLine();
        g35.StartX = 45.25283236f;
        g35.StartY = -74.30324170f;
        g35.EndX = 45.25261149f;
        g35.EndY = -74.30361913f;

        GPSLine g36 = new GPSLine();
        g36.StartX = 45.25261149f;
        g36.StartY = -74.30361913f;
        g36.EndX = 45.25253882f;
        g36.EndY = -74.30356893f;

        GPSLine g37 = new GPSLine();
        g37.StartX = 45.25253882f;
        g37.StartY = -74.30356893f;
        g37.EndX = 45.25236935f;
        g37.EndY = -74.30380207f;

        GPSLine g38 = new GPSLine();
        g38.StartX = 45.25236935f;
        g38.StartY = -74.30380207f;
        g38.EndX = 45.25232448f;
        g38.EndY = -74.30373153f;

        GPSLine g39 = new GPSLine();
        g39.StartX = 45.25232448f;
        g39.StartY = -74.30373153f;
        g39.EndX = 45.25253494f;
        g39.EndY = -74.30342881f;

        GPSLine g40 = new GPSLine();
        g40.StartX = 45.25254472f;
        g40.StartY = -74.30349712f;
        g40.EndX = 45.25244596f;
        g40.EndY = -74.30335977f;

        GPSLine g41 = new GPSLine();
        g41.StartX = 45.25244596f;
        g41.StartY = -74.30335977f;
        g41.EndX = 45.25247288f;
        g41.EndY = -74.30329866f;

        GPSLine g42 = new GPSLine();
        g42.StartX = 45.25247288f;
        g42.StartY = -74.30329866f;
        g42.EndX = 45.25261764f;
        g42.EndY = -74.30346049f;

        GPSLine g43 = new GPSLine();
        g43.StartX = 45.25261764f;
        g43.StartY = -74.30346049f;
        g43.EndX = 45.25258230f;
        g43.EndY = -74.30350732f;

        GPSLine g44 = new GPSLine();
        g44.StartX = 45.25258230f;
        g44.StartY = -74.30350732f;
        g44.EndX = 45.25263143f;
        g44.EndY = -74.30358081f;

        GPSLine g45 = new GPSLine();
        g45.StartX = 45.25260560f;
        g45.StartY = -74.30354571f;
        g45.EndX = 45.25275425f;
        g45.EndY = -74.30332466f;

        GPSLine g46 = new GPSLine();
        g46.StartX = 45.25275425f;
        g46.StartY = -74.30332466f;
        g46.EndX = 45.25268444f;
        g46.EndY = -74.30325736f;

        GPSLine g47 = new GPSLine();
        g47.StartX = 45.25268444f;
        g47.StartY = -74.30325736f;
        g47.EndX = 45.25260068f;
        g47.EndY = -74.30336967f;

        GPSLine g48 = new GPSLine();
        g48.StartX = 45.25260068f;
        g48.StartY = -74.30336967f;
        g48.EndX = 45.25252401f;
        g48.EndY = -74.30328738f;

        GPSLine g49 = new GPSLine();
        g49.StartX = 45.25248444f;
        g49.StartY = -74.30355906f;
        g49.EndX = 45.25231045f;
        g49.EndY = -74.30336790f;

        GPSLine g50 = new GPSLine();
        g50.StartX = 45.25231045f;
        g50.StartY = -74.30336790f;
        g50.EndX = 45.25221573f;
        g50.EndY = -74.30355341f;

        GPSLine g51 = new GPSLine();
        g51.StartX = 45.25221573f;
        g51.StartY = -74.30355341f;
        g51.EndX = 45.25227488f;
        g51.EndY = -74.30361110f;

        GPSLine g52 = new GPSLine();
        g52.StartX = 45.25227488f;
        g52.StartY = -74.30361110f;
        g52.EndX = 45.25216337f;
        g52.EndY = -74.30377120f;

        GPSLine g53 = new GPSLine();
        g53.StartX = 45.25216337f;
        g53.StartY = -74.30377120f;
        g53.EndX = 45.25207995f;
        g53.EndY = -74.30366012f;

        GPSLine g54 = new GPSLine();
        g54.StartX = 45.25204710f;
        g54.StartY = -74.30369835f;
        g54.EndX = 45.25221634f;
        g54.EndY = -74.30393217f;

        GPSLine g55 = new GPSLine();
        g55.StartX = 45.25221634f;
        g55.StartY = -74.30393217f;
        g55.EndX = 45.25235206f;
        g55.EndY = -74.30386188f;

        GPSLine g56 = new GPSLine();
        g56.StartX = 45.25235206f;
        g56.StartY = -74.30386188f;
        g56.EndX = 45.25215894f;
        g56.EndY = -74.30413062f;

        GPSLine g57 = new GPSLine();
        g57.StartX = 45.25215894f;
        g57.StartY = -74.30413062f;
        g57.EndX = 45.25197279f;
        g57.EndY = -74.30391074f;

        GPSLine g58 = new GPSLine();
        g58.StartX = 45.25212852f;
        g58.StartY = -74.30411302f;
        g58.EndX = 45.25184465f;
        g58.EndY = -74.30457240f;

        GPSLine g59 = new GPSLine();
        g59.StartX = 45.25184465f;
        g59.StartY = -74.30457240f;
        g59.EndX = 45.25167956f;
        g59.EndY = -74.30434143f;

        GPSLine g60 = new GPSLine();
        g60.StartX = 45.25167956f;
        g60.StartY = -74.30434143f;
        g60.EndX = 45.25183482f;
        g60.EndY = -74.30410489f;

        GPSLine g61 = new GPSLine();
        g61.StartX = 45.25168582f;
        g61.StartY = -74.30426044f;
        g61.EndX = 45.25182595f;
        g61.EndY = -74.30446751f;

        GPSLine g62 = new GPSLine();
        g62.StartX = 45.25182595f;
        g62.StartY = -74.30446751f;
        g62.EndX = 45.25193968f;
        g62.EndY = -74.30431022f;

        GPSLine g63 = new GPSLine();
        g63.StartX = 45.25193042f;
        g63.StartY = -74.30445028f;
        g63.EndX = 45.25187558f;
        g63.EndY = -74.30432845f;

        GPSLine g64 = new GPSLine();
        g64.StartX = 45.25187558f;
        g64.StartY = -74.30432845f;
        g64.EndX = 45.25192897f;
        g64.EndY = -74.30425685f;

        GPSLine g65 = new GPSLine();
        g65.StartX = 45.25192897f;
        g65.StartY = -74.30425685f;
        g65.EndX = 45.25191827f;
        g65.EndY = -74.30417950f;

        GPSLine g66 = new GPSLine();
        g66.StartX = 45.25191827f;
        g66.StartY = -74.30417950f;
        g66.EndX = 45.25198398f;
        g66.EndY = -74.30404943f;

        GPSLine g67 = new GPSLine();
        g67.StartX = 45.25195792f;
        g67.StartY = -74.30403507f;
        g67.EndX = 45.25186952f;
        g67.EndY = -74.30414589f;

        GPSLine g68 = new GPSLine();
        g68.StartX = 45.25186952f;
        g68.StartY = -74.30414589f;
        g68.EndX = 45.25178519f;
        g68.EndY = -74.30404130f;

        GPSLine g69 = new GPSLine();
        g69.StartX = 45.25178519f;
        g69.StartY = -74.30404130f;
        g69.EndX = 45.25175780f;
        g69.EndY = -74.30407959f;

        GPSLine g70 = new GPSLine();
        g70.StartX = 45.25175780f;
        g70.StartY = -74.30407959f;
        g70.EndX = 45.25182788f;
        g70.EndY = -74.30420254f;

        GPSLine g71 = new GPSLine();
        g71.StartX = 45.25216641f;
        g71.StartY = -74.30412425f;
        g71.EndX = 45.25197607f;
        g71.EndY = -74.30389410f;

        GPSLine g72 = new GPSLine();
        g72.StartX = 45.25197607f;
        g72.StartY = -74.30389410f;
        g72.EndX = 45.25205621f;
        g72.EndY = -74.30377585f;

        GPSLine g73 = new GPSLine();
        g73.StartX = 45.25205621f;
        g73.StartY = -74.30377585f;
        g73.EndX = 45.25216846f;
        g73.EndY = -74.30342005f;

        GPSLine g74 = new GPSLine();
        g74.StartX = 45.25208917f;
        g74.StartY = -74.30357391f;
        g74.EndX = 45.25218568f;
        g74.EndY = -74.30367813f;

        GPSLine g75 = new GPSLine();
        g75.StartX = 45.25218568f;
        g75.StartY = -74.30367813f;
        g75.EndX = 45.25222095f;
        g75.EndY = -74.30365094f;

        GPSLine g76 = new GPSLine();
        g76.StartX = 45.25222095f;
        g76.StartY = -74.30365094f;
        g76.EndX = 45.25215942f;
        g76.EndY = -74.30355303f;

        GPSLine g77 = new GPSLine();
        g77.StartX = 45.25215942f;
        g77.StartY = -74.30355303f;
        g77.EndX = 45.25233302f;
        g77.EndY = -74.30329602f;

        GPSLine g78 = new GPSLine();
        g78.StartX = 45.25233302f;
        g78.StartY = -74.30329602f;
        g78.EndX = 45.25244862f;
        g78.EndY = -74.30343764f;

        GPSLine g79 = new GPSLine();
        g79.StartX = 45.25235890f;
        g79.StartY = -74.30330969f;
        g79.EndX = 45.252506556f;
        g79.EndY = -74.30304967f;

        GPSLine g80 = new GPSLine();
        g80.StartX = 45.252506556f;
        g80.StartY = -74.30304967f;
        g80.EndX = 45.25242131f;
        g80.EndY = -74.30294111f;

        GPSLine g81 = new GPSLine();
        g81.StartX = 45.25242131f;
        g81.StartY = -74.30294111f;
        g81.EndX = 45.25218877f;
        g81.EndY = -74.30330342f;

        GPSLine g82 = new GPSLine();
        g82.StartX = 45.25218877f;
        g82.StartY = -74.30330342f;
        g82.EndX = 45.25226350f;
        g82.EndY = -74.30339455f;

        GPSLine g83 = new GPSLine();
        g83.StartX = 45.25245541f;
        g83.StartY = -74.30280293f;
        g83.EndX = 45.25193130f;
        g83.EndY = -74.30362216f;

        GPSLine g84 = new GPSLine();
        g84.StartX = 45.25193130f;
        g84.StartY = -74.30362216f;
        g84.EndX = 45.25196518f;
        g84.EndY = -74.30367400f;

        GPSLine g85 = new GPSLine();
        g85.StartX = 45.25193130f;
        g85.StartY = -74.30362216f;
        g85.EndX = 45.25212796f;
        g85.EndY = -74.30338012f;

        GPSLine g86 = new GPSLine();
        g86.StartX = 45.25220342f;
        g86.StartY = -74.30346004f;
        g86.EndX = 45.25206927f;
        g86.EndY = -74.30330108f;

        GPSLine g87 = new GPSLine();
        g87.StartX = 45.25206927f;
        g87.StartY = -74.30330108f;
        g87.EndX = 45.25207720f;
        g87.EndY = -74.30325967f;

        GPSLine g88 = new GPSLine();
        g88.StartX = 45.25207720f;
        g88.StartY = -74.30325967f;
        g88.EndX = 45.25196183f;
        g88.EndY = -74.30313467f;

        GPSLine g89 = new GPSLine();
        g89.StartX = 45.25196183f;
        g89.StartY = -74.30313467f;
        g89.EndX = 45.25161527f;
        g89.EndY = -74.30365123f;

        GPSLine g90 = new GPSLine();
        g90.StartX = 45.25215740f;
        g90.StartY = -74.30325557f;
        g90.EndX = 45.25213065f;
        g90.EndY = -74.30318392f;

        GPSLine g91 = new GPSLine();
        g91.StartX = 45.25213065f;
        g91.StartY = -74.30318392f;
        g91.EndX = 45.25236174f;
        g91.EndY = -74.30280707f;

        GPSLine g92 = new GPSLine();
        g92.StartX = 45.25236174f;
        g92.StartY = -74.30280707f;
        g92.EndX = 45.25226332f;
        g92.EndY = -74.30267672f;

        GPSLine g93 = new GPSLine();
        g93.StartX = 45.25226332f;
        g93.StartY = -74.30267672f;
        g93.EndX = 45.25221934f;
        g93.EndY = -74.30271375f;

        GPSLine g94 = new GPSLine();
        g94.StartX = 45.25221934f;
        g94.StartY = -74.30271375f;
        g94.EndX = 45.25217896f;
        g94.EndY = -74.30269427f;

        GPSLine g95 = new GPSLine();
        g95.StartX = 45.25217896f;
        g95.StartY = -74.30269427f;
        g95.EndX = 45.25213166f;
        g95.EndY = -74.30275334f;

        GPSLine g96 = new GPSLine();
        g96.StartX = 45.25213166f;
        g96.StartY = -74.30275334f;
        g96.EndX = 45.25212560f;
        g96.EndY = -74.30284147f;

        GPSLine g97 = new GPSLine();
        g97.StartX = 45.25212560f;
        g97.StartY = -74.30284147f;
        g97.EndX = 45.25206482f;
        g97.EndY = -74.30277634f;

        GPSLine g98 = new GPSLine();
        g98.StartX = 45.25206482f;
        g98.StartY = -74.30277634f;
        g98.EndX = 45.25199369f;
        g98.EndY = -74.30287463f;

        GPSLine g99 = new GPSLine();
        g99.StartX = 45.25199369f;
        g99.StartY = -74.30287463f;
        g99.EndX = 45.25204595f;
        g99.EndY = -74.30297253f;

        GPSLine g100 = new GPSLine();
        g100.StartX = 45.25204595f;
        g100.StartY = -74.30297253f;
        g100.EndX = 45.25202156f;
        g100.EndY = -74.30301647f;

        GPSLine g101 = new GPSLine();
        g101.StartX = 45.25202156f;
        g101.StartY = -74.30301647f;
        g101.EndX = 45.25213487f;
        g101.EndY = -74.30318166f;

        GPSLine g102 = new GPSLine();
        g102.StartX = 45.25208245f;
        g102.StartY = -74.30310513f;
        g102.EndX = 45.25205042f;
        g102.EndY = -74.30313962f;

        GPSLine g103 = new GPSLine();
        g103.StartX = 45.25205042f;
        g103.StartY = -74.30313962f;
        g103.EndX = 45.25192732f;
        g103.EndY = -74.30300201f;

        GPSLine g104 = new GPSLine();
        g104.StartX = 45.25192732f;
        g104.StartY = -74.30300201f;
        g104.EndX = 45.25179283f;
        g104.EndY = -74.30321634f;

        GPSLine g105 = new GPSLine();
        g105.StartX = 45.25167346f;
        g105.StartY = -74.30357456f;
        g105.EndX = 45.25180632f;
        g105.EndY = -74.30374935f;

        GPSLine g106 = new GPSLine();
        g106.StartX = 45.25183777f;
        g106.StartY = -74.30370772f;
        g106.EndX = 45.25177607f;
        g106.EndY = -74.30376824f;

        GPSLine g107 = new GPSLine();
        g107.StartX = 45.25177607f;
        g107.StartY = -74.30376824f;
        g107.EndX = 45.25169921f;
        g107.EndY = -74.30371212f;

        GPSLine g108 = new GPSLine();
        g108.StartX = 45.25169921f;
        g108.StartY = -74.30371212f;
        g108.EndX = 45.25148599f;
        g108.EndY = -74.30403245f;

        GPSLine g109 = new GPSLine();
        g109.StartX = 45.25154197f;
        g109.StartY = -74.30407861f;
        g109.EndX = 45.25166627f;
        g109.EndY = -74.30387328f;

        GPSLine g110 = new GPSLine();
        g110.StartX = 45.25154018f;
        g110.StartY = -74.30420418f;
        g110.EndX = 45.25159487f;
        g110.EndY = -74.30429270f;

        GPSLine g111 = new GPSLine();
        g111.StartX = 45.25159487f;
        g111.StartY = -74.30429270f;
        g111.EndX = 45.25165989f;
        g111.EndY = -74.30420342f;

        GPSLine g112 = new GPSLine();
        g112.StartX = 45.25165989f;
        g112.StartY = -74.30420342f;
        g112.EndX = 45.25144806f;
        g112.EndY = -74.30381263f;

        GPSLine g113 = new GPSLine();
        g113.StartX = 45.25144806f;
        g113.StartY = -74.30381263f;
        g113.EndX = 45.25153761f;
        g113.EndY = -74.30366095f;

        GPSLine g114 = new GPSLine();
        g114.StartX = 45.25153761f;
        g114.StartY = -74.30366095f;
        g114.EndX = 45.25152206f;
        g114.EndY = -74.30361927f;

        GPSLine g115 = new GPSLine();
        g115.StartX = 45.25152206f;
        g115.StartY = -74.30361927f;
        g115.EndX = 45.25160806f;
        g115.EndY = -74.30351736f;

        GPSLine g116 = new GPSLine();
        g116.StartX = 45.25160806f;
        g116.StartY = -74.30351736f;
        g116.EndX = 45.25163369f;
        g116.EndY = -74.30353789f;

        GPSLine g117 = new GPSLine();
        g117.StartX = 45.25163369f;
        g117.StartY = -74.30353789f;
        g117.EndX = 45.25159464f;
        g117.EndY = -74.30361498f;

        GPSLine g118 = new GPSLine();
        g118.StartX = 45.25159464f;
        g118.StartY = -74.30361498f;
        g118.EndX = 45.25160356f;
        g118.EndY = -74.30366244f;

        GPSLine g119 = new GPSLine();
        g118.StartX = 45.25150756f;
        g118.StartY = -74.30406932f;
        g118.EndX = 45.25146902f;
        g118.EndY = -74.30411845f;

        gpsLines.Add(g0);gpsLines.Add(g1); gpsLines.Add(g2); gpsLines.Add(g3); gpsLines.Add(g4); gpsLines.Add(g5); gpsLines.Add(g6); gpsLines.Add(g7); gpsLines.Add(g8); gpsLines.Add(g9);
        gpsLines.Add(g10); gpsLines.Add(g11); gpsLines.Add(g12); gpsLines.Add(g13); gpsLines.Add(g14); gpsLines.Add(g15); gpsLines.Add(g16); gpsLines.Add(g17); gpsLines.Add(g18); gpsLines.Add(g19);
        gpsLines.Add(g20); gpsLines.Add(g21); gpsLines.Add(g22); gpsLines.Add(g23); gpsLines.Add(g24); gpsLines.Add(g25); gpsLines.Add(g26); gpsLines.Add(g27); gpsLines.Add(g28); gpsLines.Add(g29);
        gpsLines.Add(g30); gpsLines.Add(g31); gpsLines.Add(g32); gpsLines.Add(g33); gpsLines.Add(g34); gpsLines.Add(g35); gpsLines.Add(g36); gpsLines.Add(g37); gpsLines.Add(g38); gpsLines.Add(g39);
        gpsLines.Add(g40); gpsLines.Add(g41); gpsLines.Add(g42); gpsLines.Add(g43); gpsLines.Add(g44); gpsLines.Add(g45); gpsLines.Add(g46); gpsLines.Add(g47); gpsLines.Add(g48); gpsLines.Add(g49);
        gpsLines.Add(g50); gpsLines.Add(g51); gpsLines.Add(g52); gpsLines.Add(g53); gpsLines.Add(g54); gpsLines.Add(g55); gpsLines.Add(g56); gpsLines.Add(g57); gpsLines.Add(g58); gpsLines.Add(g59);
        gpsLines.Add(g60); gpsLines.Add(g61); gpsLines.Add(g62); gpsLines.Add(g63); gpsLines.Add(g64); gpsLines.Add(g65); gpsLines.Add(g66); gpsLines.Add(g67); gpsLines.Add(g68); gpsLines.Add(g69);
        gpsLines.Add(g70); gpsLines.Add(g71); gpsLines.Add(g72); gpsLines.Add(g73); gpsLines.Add(g74); gpsLines.Add(g75); gpsLines.Add(g76); gpsLines.Add(g77); gpsLines.Add(g78); gpsLines.Add(g79);
        gpsLines.Add(g80); gpsLines.Add(g81); gpsLines.Add(g82); gpsLines.Add(g83); gpsLines.Add(g84); gpsLines.Add(g85); gpsLines.Add(g86); gpsLines.Add(g87); gpsLines.Add(g88); gpsLines.Add(g89);
        gpsLines.Add(g90); gpsLines.Add(g91); gpsLines.Add(g92); gpsLines.Add(g93); gpsLines.Add(g94); gpsLines.Add(g95); gpsLines.Add(g96); gpsLines.Add(g97); gpsLines.Add(g98); gpsLines.Add(g99);
        gpsLines.Add(g100); gpsLines.Add(g101); gpsLines.Add(g102); gpsLines.Add(g103); gpsLines.Add(g104); gpsLines.Add(g105); gpsLines.Add(g106); gpsLines.Add(g107); gpsLines.Add(g108); gpsLines.Add(g109);
        gpsLines.Add(g110); gpsLines.Add(g111); gpsLines.Add(g112); gpsLines.Add(g113); gpsLines.Add(g114); gpsLines.Add(g115); gpsLines.Add(g116); gpsLines.Add(g117); gpsLines.Add(g118); gpsLines.Add(g119);

    }
}
