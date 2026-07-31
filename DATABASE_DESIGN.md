# SocialCharge Database Design

## 1. Users

ตารางผู้ใช้งานจาก ASP.NET Core Identity

| Column | Type | Description |
|---|---|---|
| Id | string | รหัสผู้ใช้งาน |
| UserName | string | ชื่อผู้ใช้งาน |
| Email | string | อีเมล |
| PasswordHash | string | รหัสผ่านที่ถูกเข้ารหัส |

## 2. Categories

ตารางประเภทของกิจกรรม

| Column | Type | Description |
|---|---|---|
| Id | int | รหัสหมวดหมู่ |
| Name | string | ชื่อหมวดหมู่ |
| Icon | string | Emoji หรือไอคอน |

ตัวอย่างหมวดหมู่:

- Study
- Work
- Friends
- Family
- Exercise
- Party
- Alone Time
- Other

## 3. SocialActivities

ตารางบันทึกกิจกรรมและการเปลี่ยนแปลงพลังงาน

| Column | Type | Description |
|---|---|---|
| Id | int | รหัสกิจกรรม |
| UserId | string | ผู้สร้างกิจกรรม |
| CategoryId | int | หมวดหมู่กิจกรรม |
| Title | string | ชื่อกิจกรรม |
| ActivityDate | DateTime | วันที่และเวลาที่ทำกิจกรรม |
| EnergyBefore | int | พลังงานก่อนทำกิจกรรม 1-10 |
| EnergyAfter | int | พลังงานหลังทำกิจกรรม 1-10 |
| EnjoymentScore | int | คะแนนความสนุก 1-10 |
| PeopleCount | int | จำนวนคนที่พบ |
| Note | string | หมายเหตุ |
| CreatedAt | DateTime | วันที่สร้างข้อมูล |
| UpdatedAt | DateTime? | วันที่แก้ไขข้อมูลล่าสุด |

## Relationships

- User หนึ่งคนมี SocialActivities ได้หลายรายการ
- Category หนึ่งหมวดมี SocialActivities ได้หลายรายการ
- SocialActivity หนึ่งรายการเป็นของ User หนึ่งคน
- SocialActivity หนึ่งรายการอยู่ใน Category หนึ่งหมวด

## Business Logic

EnergyChange ไม่เก็บลงฐานข้อมูล แต่คำนวณจาก:

EnergyChange = EnergyAfter - EnergyBefore

สถานะพลังงาน:

- ตั้งแต่ +3 ขึ้นไป = Charged
- +1 ถึง +2 = Slightly Charged
- 0 = Neutral
- -1 ถึง -2 = Slightly Drained
- ตั้งแต่ -3 ลงไป = Drained