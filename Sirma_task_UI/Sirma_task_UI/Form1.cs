using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace Sirma_task_UI
{
    public partial class Form1 : Form
    {
        String stdDetailsHead = "{0, -10}{1, 20}{2, 30}{3, 40}";
        String stdDetailsBody = "{0, -10}{1, 21}{2, 31}{3, 36}";
        public Form1()
        {
            InitializeComponent();
        }
        List<List<string>> data = new List<List<string>>();
        List<Data> items = new List<Data>();
        private void btn_Upload_Click(object sender, EventArgs e)
        {
            lbox_commonProjects.Items.Clear();
            lbl_maxPairInfo.Text = "";
            lbox_commonProjects.Items.Add(String.Format(stdDetailsHead, "Emp1Id", "Emp2Id",
                "ProjectId", "Days Worked Together"));
            btn_Display.Enabled = true;
            data = new List<List<string>>();
            items = new List<Data>();
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\csv";
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFile.FileName);
                string extension = fi.Extension;

                if (extension.Equals(".csv"))
                {
                    using (TextFieldParser csvParser = new TextFieldParser(openFile.FileName))
                    {
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        string head = csvParser.ReadLine();

                        if (head == null || !head.Equals("EmpID;ProjectID;DateFrom;DateTo"))
                        {
                            MessageBox.Show("Unsupported file structure");
                            btn_Display.Enabled = false;
                        }
                            

                        while (!csvParser.EndOfData)
                        {
                            string[] fields = csvParser.ReadFields();
                            List<string> values = fields[0].Split(";").ToList();
                            data.Add(values);
                        }
                    }
                }
                else if (extension.Equals(".txt") || extension.Equals(".json"))
                {
                    using (StreamReader r = new StreamReader(openFile.FileName))
                    {
                        string json = r.ReadToEnd();
                        try
                        {
                            items = JsonConvert.DeserializeObject<List<Data>>(json);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Unsupported file structure");
                            btn_Display.Enabled = false;
                        }
                        
                    }

                    for (int i = 0; i < items.Count; i++)
                    {
                        List<string> currentData = new List<string>();
                        currentData.Add(items[i].EmpID);
                        currentData.Add(items[i].ProjectID);
                        currentData.Add(items[i].DateFrom);
                        currentData.Add(items[i].DateTo);
                        data.Add(currentData);
                    }
                }
                else
                {
                    MessageBox.Show("Unsupported file type");
                    btn_Display.Enabled = false;
                }
            }
        }

        public static List<List<string>> GetAllMatchingWorkers(List<List<string>> data)
        {
            List<List<string>> workingDetails = new List<List<string>>();
            try
            {

                for (int i = 0; i < data.Count - 1; i++)
                {
                    DateTime startDate1 = DateTime.Parse(data[i][2]);
                    DateTime endDate1 = DateTime.Now.Date;
                    if (!data[i][3].Equals(""))
                        endDate1 = DateTime.Parse(data[i][3]);
                    for (int j = i + 1; j <= data.Count - 1; j++)
                    {
                        DateTime startDate2 = DateTime.Parse(data[j][2]);
                        DateTime endDate2 = DateTime.Now.Date;
                        if (!data[j][3].Equals(""))
                            endDate2 = DateTime.Parse(data[j][3]);
                        if (data[i][1].Equals(data[j][1]))
                        {
                            List<string> currentDetails = new List<string>();
                            string daysWorkedTogether = WorkedTogether(startDate1,
                                endDate1, startDate2, endDate2);
                            if (daysWorkedTogether == "0")
                                continue;
                            currentDetails.Add(data[i][0]);
                            currentDetails.Add(data[j][0]);
                            currentDetails.Add(data[i][1]);
                            currentDetails.Add(daysWorkedTogether);
                            workingDetails.Add(currentDetails);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Unable to convert to datetime");
                return null;
            }
            return workingDetails;
        }

        public static List<string> GetMaxPair(List<List<string>> workingDetails)
        {
            int maxIndex = 0;
            List<string> result = new List<string>();
            if (workingDetails.Count > 0)
            {
                int max = Convert.ToInt32(workingDetails[0][3]);
                for (int i = 1; i < workingDetails.Count; i++)
                {
                    int current = Convert.ToInt32(workingDetails[i][3]);
                    if (current > max)
                    {
                        max = current;
                        maxIndex = i;
                    }
                }
                result = workingDetails[maxIndex];
                return result;
            }
            else
            {
                return null;
            }
        }

        public static List<List<string>> ExtractMatchingProjects(List<string> result,
            List<List<string>> workingDetails)
        {
            string emp1 = result[0];
            string emp2 = result[1];
            List<List<string>> matchingProjects = new List<List<string>>();
            for (int i = 0; i < workingDetails.Count; i++)
            {
                if (workingDetails[i][0].Equals(emp1) &&
                    workingDetails[i][1].Equals(emp2) ||
                    workingDetails[i][0].Equals(emp2) &&
                    workingDetails[i][1].Equals(emp1))
                {
                    List<string> currentProjectInfo = new List<string>();
                    currentProjectInfo.Add(workingDetails[i][0]);
                    currentProjectInfo.Add(workingDetails[i][1]);
                    currentProjectInfo.Add(workingDetails[i][2]);
                    currentProjectInfo.Add(workingDetails[i][3]);
                    matchingProjects.Add(currentProjectInfo);
                }
            }
            return matchingProjects;
        }

        public static string WorkedTogether(DateTime startDate1, DateTime endDate1,
            DateTime startDate2, DateTime endDate2)
        {
            if (startDate1 < startDate2)
            {
                if (endDate1 < startDate2)
                    return "0";
                else
                {
                    string result = (GetEarlierDate(endDate1, endDate2) - startDate2).ToString();
                    string[] daysAndTime = result.Split(".");
                    return daysAndTime[0];
                }
            }
            else if (startDate2 < startDate1)
            {
                if (endDate2 < startDate1)
                    return "0";
                else
                {
                    string result = (GetEarlierDate(endDate1, endDate2) - startDate1).ToString();
                    string[] daysAndTime = result.Split(".");
                    return daysAndTime[0];
                }
            }
            else
            {
                string result = (GetEarlierDate(endDate1, endDate2) - startDate1).ToString();
                string[] daysAndTime = result.Split(".");
                return daysAndTime[0];
            }
        }

        public static DateTime GetEarlierDate(DateTime d1, DateTime d2)
        {
            return d1 <= d2 ? d1 : d2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbox_commonProjects.Items.Add(String.Format(stdDetailsHead, "Emp1Id", "Emp2Id", 
                "ProjectId", "Days Worked Together"));
        }

        private void btn_Display_Click(object sender, EventArgs e)
        {
            String Emp1Id, Emp2Id, ProjectId, days;
            var workingDetails = GetAllMatchingWorkers(data);
            if (workingDetails == null)
            {
                return;
            }
            var result = GetMaxPair(workingDetails);

            if (result == null)
            {
                lbl_maxPairInfo.Text = "There is no pair of coworkers";
                return;
            }
                
            lbl_maxPairInfo.Text = String.Format("Emp1Id: {0}\n" +
                "Emp2Id: {1}\n" +
                "ProjectId: {2}\n" +
                "Days worked together: {3}", result[0], result[1], result[2], result[3]);

            List<List<string>> matchingProjects = ExtractMatchingProjects(result, workingDetails);

            for (int i = 0; i < matchingProjects.Count; i++)
            {
                Emp1Id = matchingProjects[i][0];
                Emp2Id = matchingProjects[i][1];
                ProjectId = matchingProjects[i][2];
                days = matchingProjects[i][3];
                lbox_commonProjects.Items.Add(String.Format(stdDetailsBody, Emp1Id, Emp2Id,
                    ProjectId, days));
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}