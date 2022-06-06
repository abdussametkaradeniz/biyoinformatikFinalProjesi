using System.Collections;

namespace BiyoInformatikFinalProject
{
    public partial class Form1 : Form
    {
        /* Buton browse ve select file dosyay� se�me i�lemleri i�in kullan�ld� */

        /* Okuma i�lemleri i�in ReadFile kullan�lacak. Her sat�r bir sequence kabul edildi */
        
        /* �lk ad�m array i�erisindeki en uzun eleman� bulmak. */

        /* Bulunan en uzun kombinasyonun uzunlu�u 1.2 ile �arpal�m */

        /* Yeni en uzun sequence'e fazlal��� kadar gap atayal�m */

        /* Yeni en uzun sequence ile di�erleri aras�ndaki fark kadar di�erlerine gap atal�m.*/
        
        /* bir sonraki ad�mda bulunan en uzun gen hari� di�erlerini bir arraya at�p bunlar� gen havuzu olarak kullanaca��z*/
        
        /* k���k olan genleri en uzun genin uzunlu�una e�it olana kadar gap de�eriyle dolduraca��z */

        /* Art�k elimdeki t�m varyasyonlar gap ile doldu */

        /* Her sequence i�in gap indekslerini tutal�m */

        /* En uzun sequence uzunlu�una 1 ekleyelim bu bizim kesme noktam�z olsun */

        /* Belirli bir girdi say�s� kadar �rne�in 100 tane olsun. Kromozom olu�tural�m */

        /* Olu�turulan bu kromozomlar bir pop�lasyon oldular. */

        /* Olu�an yeni pop�lasyon i�erisinde birbirlerine en �ok benzeyenlerden belli bir oranda alal�m bunlar ata olsun */


        /* global de�i�kenler/tan�mlamalar */
        OpenFileDialog openfiledialog = new OpenFileDialog();
        Random random = new Random();
        
        List<holdSequence> holdSequences = new List<holdSequence>();

        List<string> sequenceArray = new List<string>();
        List<string> population = new List<string>();
        List<string> nextGeneration = new List<string>();

        List<int> gapIndexList = new List<int>();

        Dictionary<string, List<int>> dictionarySequenceWithgapIndex = new Dictionary<string, List<int>>();

        public double maxStringLengthOnArray = 0.0;
        public int indexOfMaxSequenceLength = 0;
        public int populationNumber = 10, stepCount = 0;
        public int fitness = 0;


        public string cromosomParent = string.Empty;
        public string sequenceTxtPath;
        string longestSequenceWithGap = string.Empty;

        public bool found = false; //e�er y�zde y�z e�le�me olursa veya bulunursa true olacak
        


        public Form1()
        {
            InitializeComponent();
        }

        //dosya se�tiren metot
        public void SelectFile()
        {
            openfiledialog.RestoreDirectory = true;
            openfiledialog.Title = "Browse Txt Sequence";
            openfiledialog.DefaultExt = "txt";
            openfiledialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openfiledialog.CheckFileExists = true;
            openfiledialog.CheckPathExists = true;
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                txtSequencePath.Text = openfiledialog.FileName;
                sequenceTxtPath = openfiledialog.FileName.ToString();
            }
        }

        //txdeki sat�rlar� bir arrayin i�erisine atad�k.
        public void ReadTxt(string sequencePath)
        {
            if (File.Exists(sequencePath))
            {
                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(sequencePath))
                {                  
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        sequenceArray.Add(line);
                    }
                    file.Close();                    
                }
            }
        }
        

        //max uzunlu�a sahip olan kelimeyi bulduk
        public string maxSequenceLength()
        {
            string parent = string.Empty;
            int count = 0;
            foreach (string s in sequenceArray)
            {
                if (s.Length > maxStringLengthOnArray)
                {
                    maxStringLengthOnArray = s.Length;
                    parent = s;
                    indexOfMaxSequenceLength = count;
                }
                count++;
            }
            return parent;
        }
        
        //max uzunlu�a sahip olan kelimenin uzunlu�unu 1.2 ile �arp
        public void maxSequenceLengthIncrease()
        {
            int oldMaxStringLength = (int) maxStringLengthOnArray;
            maxStringLengthOnArray = (int) (maxStringLengthOnArray * 1.2);
            int gapCounter = neededGapCount(oldMaxStringLength, maxStringLengthOnArray);
            longestSequenceWithGap = returnLongestSequenceWithGap(gapCounter);
        }

        //max stringin uzunlu�u artt�r�lm�� halinden �imdiki halini ��kar.
        public int neededGapCount(int oldMaxStringLength, double newMaxStringLength)
        {
            return (int) newMaxStringLength - oldMaxStringLength;
        }
        
        //istenen gap say�s� kadar en uzun stringe "-" i�areti at
        public string returnLongestSequenceWithGap(int gapCounter)
        {
            sequenceArray[indexOfMaxSequenceLength] = shuffleWithDash(sequenceArray[indexOfMaxSequenceLength],gapCounter);
            return sequenceArray[indexOfMaxSequenceLength];
        }
        
        //di�er kalan sequence'ler i�in gerekti�i kadar random gap att�ran metot
        public void fillOtherSequencesWithGap()
        {
            for (int i = 0; i < sequenceArray.Count; i++)
            {
                int neededGapCount = longestSequenceWithGap.Length - sequenceArray[i].Length;
                sequenceArray[i] = shuffleWithDash(sequenceArray[i], neededGapCount);
            }        
        }
    
        //gelen dash say�s�na g�re, g�nderilen stringe random dash yerle�tiren metot
        public string shuffleWithDash(string chromosome, int dashCount)
        {
            for (int i = 0; i < dashCount; i++)
            {
                int x = random.Next(chromosome.Length);
                chromosome = chromosome.Insert(x, "-");
            }
            return chromosome;
        }

        //gaplerin indexlerini bir listeye doldural�m ve bu listeyi, sequence'in key oldu�u bir dictionarye atal�m.
        public void fillGapIndexList()
        {
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //int uzunluk = "MMGLSDGMWQLVLNVWGKVMADIPGHGQMVLIRLFKGHPMTLMKFDKFKHLKSMDMMKAS".Length;
            SelectFile();
            ReadTxt(sequenceTxtPath);
            cromosomParent = maxSequenceLength();
            maxSequenceLengthIncrease();
            fillOtherSequencesWithGap();
            fillGapIndexList();


        }


        //





    }
}