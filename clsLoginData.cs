using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Windows.Forms;

public class clsLoginData
{
    private const string FilePath = "users.txt";

    // الدالة الرئيسية
    public static void UpdateUserData(string username, string password, bool saveUser)
    {
        var users = File.Exists(FilePath) ?
                   File.ReadAllLines(FilePath).ToList() :
                   new System.Collections.Generic.List<string>();

        // البحث عن المستخدم إن وجد
        var userLine = users.FirstOrDefault(line => line.StartsWith(username + ":"));

        if (saveUser)
        {
            // إضافة أو تحديث
            var newLine = $"{username}:{password}";

            if (userLine != null)
                users[users.IndexOf(userLine)] = newLine; // تحديث
            else
                users.Add(newLine); // إضافة
        }
        else
        {
            // حذف إن وجد
            if (userLine != null)
                users.Remove(userLine);
        }

        // حفظ التغييرات
        File.WriteAllLines(FilePath, users);
    }

    public static void RecrdsNum(DataGridView dataGridView , Label label)
    {
        label.Text = (dataGridView.Rows.Count-1).ToString();
    }
}