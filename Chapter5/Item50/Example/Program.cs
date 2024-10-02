using System;

public class FileManager
{
    public void DeleteFile(string fileName, bool isAdmin)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), "파일 이름은 null이거나 비어 있을 수 없습니다.");
        }

        // 파일 삭제 시 발생할 수 있는 예외 시뮬레이션
        throw new UnauthorizedAccessException("파일 삭제 권한이 없습니다.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        FileManager fileManager = new FileManager();

        try
        {
            // 관리자 여부에 따라 예외 처리가 다르게 진행됨
            fileManager.DeleteFile("important_file.txt", isAdmin: false);
        }
        // 예외 필터로 관리자일 때만 예외를 다시 던지지 않고 처리
        catch (UnauthorizedAccessException ex) when (!IsAdmin())
        {
            Console.WriteLine("권한이 없으므로 파일을 삭제할 수 없습니다.");
        }
        catch (UnauthorizedAccessException ex) when (IsAdmin())
        {
            Console.WriteLine("관리자 권한이 필요합니다. 관리자 모드로 다시 시도하세요.");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"에러: {ex.Message}");
        }
    }

    // 관리자 여부를 확인하는 메서드
    static bool IsAdmin()
    {
        // 실제 관리자 여부를 확인하는 로직이 있다고 가정
        return false; // 여기서는 관리자 권한이 없다고 가정
    }
}
