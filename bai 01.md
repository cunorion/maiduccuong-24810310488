# I. PHẦN LÝ THUYẾT & CÂU HỎI NGẮN

## Câu 1: Trình bày sự khác nhau giữa Value Types (Kiểu giá trị) và Reference Types (Kiểu tham chiếu) trong C# về cơ chế lưu trữ vùng nhớ (Stack vs Heap).

- Các kiểu dữ liệu tiêu biểu:

  - Value Types: Gồm các kiểu dữ liệu nguyên thủy như `int`, `float`, `double`, `bool`, `char`, các kiểu cấu trúc `struct`, và `enum`.

  - Reference Types: Gồm `class`, `interface`, `delegate`, `string`, `object`, và các mảng (`array`).

- Cơ chế lưu trữ vùng nhớ:

  - Value Types: Lưu trữ trực tiếp giá trị của dữ liệu trên bộ nhớ Stack (Trường hợp đặc biệt: Nếu biến kiểu giá trị là thuộc tính/trường nằm bên trong một đối tượng `class`, giá trị đó sẽ sống trên Heap cùng với đối tượng chứa nó).

  - Reference Types: Dữ liệu thực sự (đối tượng) được lưu trữ trên bộ nhớ Heap. Bộ nhớ Stack chỉ lưu biến tham chiếu chứa địa chỉ ô nhớ dẫn đến đối tượng trên Heap.

- Cơ chế gán và sao chép (Assignment):

  - Value Types: Khi gán biến này cho biến khác (ví dụ: `a = b`), C# thực hiện sao chép toàn bộ giá trị dữ liệu sang vùng nhớ mới. Hai biến hoạt động hoàn toàn độc lập, thay đổi một biến không ảnh hưởng đến biến còn lại.

  - Reference Types: Khi gán biến này cho biến khác (ví dụ: `objA = objB`), C# chỉ sao chép địa chỉ tham chiếu. Cả hai biến lúc này đều trỏ đến cùng một đối tượng trên Heap. Do đó, thay đổi qua biến này sẽ phản ánh trực tiếp lên biến kia.

- Quản lý bộ nhớ và hiệu năng:

  - Value Types: Được giải phóng tự động ngay khi khối lệnh (scope/stack frame) kết thúc. Tốc độ truy xuất rất nhanh.

  - Reference Types: Được quản lý tự động bởi trình thu gom rác Garbage Collector (GC). GC sẽ thu hồi vùng nhớ Heap khi không còn biến tham chiếu nào trỏ đến đối tượng nữa. Tốc độ truy xuất chậm hơn một chút do phải trải qua bước giải mã địa chỉ.

## Câu 2: Tính năng Init-only Properties (init) trong C# 9/10 khác gì so với thuộc tính có set thông thường? Nêu trường hợp sử dụng thực tế.

- Sự khác nhau về thời điểm gán giá trị:

  - Thuộc tính có `set` thông thường: Cho phép gán hoặc thay đổi giá trị bất kỳ lúc nào trong suốt vòng đời của đối tượng (Mutable).

  - Thuộc tính `init` (Init-only Property): Chỉ cho phép gán giá trị một lần duy nhất tại thời điểm khởi tạo đối tượng (qua Constructor hoặc Object Initializer Syntax). Sau khi đối tượng khởi tạo xong, thuộc tính này sẽ trở thành hằng số chỉ đọc (Read-only / Immutable) và không thể thay đổi từ bên ngoài.

- Cú pháp khởi tạo linh hoạt:

  - Khác với thuộc tính chỉ có `get` kết hợp với `readonly` field (bắt buộc phải gán qua hàm tạo Constructor với danh sách tham số cố định), `init` cho phép người dùng khởi tạo đối tượng linh hoạt bằng cú pháp khởi tạo `new Person { Name = "An" }` mà vẫn đảm bảo tính bất biến (Immutability).

- Trường hợp sử dụng thực tế:

  - Thiết kế các DTO (Data Transfer Object) hoặc Model: Dùng khi chuyển đổi dữ liệu giữa các tầng kiến trúc (ví dụ: nhận dữ liệu từ API hoặc Database), đảm bảo dữ liệu sau khi nhận về sẽ không bị vô tình chỉnh sửa.

  - Làm việc với các đối tượng bất biến (Immutable Objects) trong ứng dụng đa luồng (Multi-threading): Đảm bảo an toàn luồng (Thread-safety) vì các thuộc tính không thể bị thay đổi bởi luồng khác sau khi tạo.

  - Kết hợp với tính năng Record (`record`) trong C#: Giúp tạo các mô hình dữ liệu dựa trên giá trị mà không lo ngại về side-effect (tác dụng phụ do sửa đổi dữ liệu ngoài ý muốn).

## Câu 3: Phân biệt sự khác nhau giữa phương thức virtual ở lớp cha và phương thức override ở lớp con khi triển khai tính Đa hình (Polymorphism).

- Khái niệm và Vai trò:

  - Phương thức `virtual` (ở lớp cha): Khai báo một phương thức trong lớp cơ sở và cho phép các lớp dẫn xuất (lớp con) có thể ghi đè lại nếu cần. Nó định nghĩa hành vi mặc định và mở ra cơ chế đa hình động (Dynamic Polymorphism / Late Binding).

  - Phương thức `override` (ở lớp con): Khai báo ở lớp con nhằm cung cấp triển khai mới hoàn toàn, ghi đè lên triển khai của phương thức `virtual` từ lớp cha.

- Nơi khai báo và Yêu cầu từ từ khóa:

  - `virtual`: Chỉ được khai báo tại lớp cha (Base Class).

  - `override`: Chỉ được khai báo tại lớp con (Derived Class) và bắt buộc phương thức ở lớp cha phải được đánh dấu là `virtual`, `abstract`, hoặc `override`.

- Cơ chế thực thi (Dynamic Polymorphism):

  - Khi gọi phương thức thông qua một biến tham chiếu của lớp cha nhưng đang trỏ đến đối tượng của lớp con (ví dụ: `Animal animal = new Dog(); animal.MakeSound();`):

    - Trình biên dịch sẽ kiểm tra bảng phương thức ảo (V-Table) tại thời điểm chạy (Runtime).

    - Do lớp con đã `override` phương thức `MakeSound`, chương trình sẽ ưu tiên thực thi phiên bản của lớp con (`Dog`) thay vì phiên bản `virtual` của lớp cha (`Animal`).

- Tính bắt buộc triển khai:

  - `virtual`: Không bắt buộc lớp con phải `override`. Nếu lớp con không ghi đè, nó sẽ tự động sử dụng đoạn mã mặc định do lớp cha cung cấp.

  - `override`: Là hành động chủ động ghi đè hành vi cũ để phù hợp với ngữ cảnh của lớp con.

## Câu 4: Tại sao một thành phần được khai báo là static trong Lớp (Class) lại không thể truy xuất thông qua một thể hiện (Object Instance) được tạo bằng toán tử new?

- Quyền sở hữu và Quản lý bộ nhớ:

  - Thành phần `static` (Static Member) thuộc sở hữu của chính Lớp đó (Class level), không thuộc về bất kỳ thể hiện cụ thể nào (Instance level).

  - Vùng nhớ cho các thành phần `static` chỉ được cấp phát một lần duy nhất trên vùng nhớ High Frequency Heap khi lớp được nạp vào RAM. Trong khi đó, các thể hiện tạo ra bằng toán tử `new` nằm ở các vùng nhớ Heap riêng biệt khác nhau.

- Định hướng thiết kế của ngôn ngữ C#:

  - C# được thiết kế chặt chẽ theo nguyên tắc Type-safety và Clear Semantics (Nghĩa rõ ràng). Việc ngăn chặn truy cập `static` qua thể hiện đối tượng giúp phân biệt rõ ràng giữa dữ liệu riêng biệt của từng đối tượng và dữ liệu dùng chung/tiện ích toàn cục của lớp.

- Tránh hiện tượng mơ hồ và lỗi logic:

  - Nếu C# cho phép viết `instance.StaticMethod()`, lập trình viên dễ nhầm tưởng rằng hàm đó đang thao tác trên dữ liệu nội bộ của `instance` đó, trong khi thực tế nó đang thao tác trên trạng thái dùng chung toàn ứng dụng.

- Cách truy xuất đúng quy định:

  - Phải gọi trực tiếp thông qua tên lớp: `TenLop.ThanhPhanStatic` (Ví dụ: `Math.Sqrt()`, `Console.WriteLine()`).