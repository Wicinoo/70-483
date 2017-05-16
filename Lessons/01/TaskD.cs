using System;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD {
        private static delegate MetalSinger GetSomePrettyCoolMusic();
        public static void Run() {
            MetalSinger singer;
            GetSomePrettyCoolMusic genericMetal = GetGenericPrettyCoolMusic;
            singer = genericMetal();

            GetSomePrettyCoolMusic trueFinnishMetal = SaadaJoitakinMelkoViileaMusiikkia;
            singer = trueFinnishMetal();
        }

        public static MetalSinger GetGenericPrettyCoolMusic() {
            return new MetalSinger();
        }

        public static FinnishMetalSinger SaadaJoitakinMelkoViileaMusiikkia() {
            return new FinnishMetalSinger();
        }
    }

    public class MetalSinger {

    }

    public class FinnishMetalSinger : MetalSinger {

    }
}