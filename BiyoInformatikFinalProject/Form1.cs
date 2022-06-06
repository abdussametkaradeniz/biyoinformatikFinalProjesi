using System.Collections;

namespace BiyoInformatikFinalProject
{
    public partial class Form1 : Form
    {
        /* Buton browse ve select file dosyayý seçme iþlemleri için kullanýldý */

        /* Okuma iþlemleri için ReadFile kullanýlacak. Her satýr bir sequence kabul edildi */
        
        /* Ýlk adým array içerisindeki en uzun elemaný bulmak. */

        /* Bulunan en uzun kombinasyonun uzunluðu 1.2 ile çarpalým */

        /* Yeni en uzun sequence'e fazlalýðý kadar gap atayalým */

        /* Yeni en uzun sequence ile diðerleri arasýndaki fark kadar diðerlerine gap atalým.*/
        
        /* bir sonraki adýmda bulunan en uzun gen hariç diðerlerini bir arraya atýp bunlarý gen havuzu olarak kullanacaðýz*/
        
        /* küçük olan genleri en uzun genin uzunluðuna eþit olana kadar gap deðeriyle dolduracaðýz */

        /* Artýk elimdeki tüm varyasyonlar gap ile doldu */

        /* Her sequence için gap indekslerini tutalým */

        /* En uzun sequence uzunluðuna 1 ekleyelim bu bizim kesme noktamýz olsun */

        /* Belirli bir girdi sayýsý kadar örneðin 100 tane olsun. Kromozom oluþturalým */

        /* Oluþturulan bu kromozomlar bir popülasyon oldular. */

        /* Oluþan yeni popülasyon içerisinde birbirlerine en çok benzeyenlerden belli bir oranda alalým bunlar ata olsun */


        /* global deðiþkenler/tanýmlamalar */
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

        public bool found = false; //eðer yüzde yüz eþleþme olursa veya bulunursa true olacak
        


        public Form1()
        {
            InitializeComponent();
        }

        //dosya seçtiren metot
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

        //txdeki satýrlarý bir arrayin içerisine atadýk.
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
        

        //max uzunluða sahip olan kelimeyi bulduk
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
        
        //max uzunluða sahip olan kelimenin uzunluðunu 1.2 ile çarp
        public void maxSequenceLengthIncrease()
        {
            int oldMaxStringLength = (int) maxStringLengthOnArray;
            maxStringLengthOnArray = (int) (maxStringLengthOnArray * 1.2);
            int gapCounter = neededGapCount(oldMaxStringLength, maxStringLengthOnArray);
            longestSequenceWithGap = returnLongestSequenceWithGap(gapCounter);
        }

        //max stringin uzunluðu arttýrýlmýþ halinden þimdiki halini çýkar.
        public int neededGapCount(int oldMaxStringLength, double newMaxStringLength)
        {
            return (int) newMaxStringLength - oldMaxStringLength;
        }
        
        //istenen gap sayýsý kadar en uzun stringe "-" iþareti at
        public string returnLongestSequenceWithGap(int gapCounter)
        {
            sequenceArray[indexOfMaxSequenceLength] = shuffleWithDash(sequenceArray[indexOfMaxSequenceLength],gapCounter);
            return sequenceArray[indexOfMaxSequenceLength];
        }
        
        //diðer kalan sequence'ler için gerektiði kadar random gap attýran metot
        public void fillOtherSequencesWithGap()
        {
            for (int i = 0; i < sequenceArray.Count; i++)
            {
                int neededGapCount = longestSequenceWithGap.Length - sequenceArray[i].Length;
                sequenceArray[i] = shuffleWithDash(sequenceArray[i], neededGapCount);
            }        
        }
    
        //gelen dash sayýsýna göre, gönderilen stringe random dash yerleþtiren metot
        public string shuffleWithDash(string chromosome, int dashCount)
        {
            for (int i = 0; i < dashCount; i++)
            {
                int x = random.Next(chromosome.Length);
                chromosome = chromosome.Insert(x, "-");
            }
            return chromosome;
        }

        //gaplerin indexlerini bir listeye dolduralým ve bu listeyi, sequence'in key olduðu bir dictionarye atalým.
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