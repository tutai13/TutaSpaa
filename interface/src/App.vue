<template>
  <div id="app">
    <nav class="navbar">
      <ul class="nav-links">
        <li>
          <a href="#"><i class="fa-solid fa-house"></i> Trang chủ</a>
        </li>
        <li>
          <a href="#"><i class="fa-solid fa-briefcase"></i> Dịch vụ</a>
        </li>
        <li>
          <a href="#"><i class="fa-regular fa-calendar-check"></i> Đặt lịch</a>
        </li>
        <li>
          <a href="#"><i class="fa-solid fa-circle-info"></i> Giới thiệu</a>
        </li>
        <li>
          <a href="#"><i class="fa-solid fa-envelope"></i> Liên hệ</a>
        </li>
      </ul>
      <div class="user-icon">
        <i class="fa-solid fa-circle-user"></i>
        <i class="fa-regular fa-calendar-check"></i>
      </div>
    </nav>

    <main class="main-content">
      <router-view />
    </main>
  </div>
</template>

<script setup>
// Không cần khai báo gì nếu không có logic xử lý
</script>

<style scoped>
body {
  margin: 0;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
}

.navbar {
  background-color: #2c3e50;
  color: white;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 12px 20px;
}

.nav-links {
  list-style: none;
  display: flex;
  gap: 20px;
  margin: 0;
  padding: 0;
}

.nav-links li a {
  color: white;
  text-decoration: none;
  font-weight: 500;
  transition: color 0.3s ease;
}

.nav-links li a:hover {
  color: #f39c12;
}

.nav-links i {
  margin-right: 8px;
}

.user-icon i {
  font-size: 24px;
  cursor: pointer;
}

.main-content {
  padding: 20px;
}
</style>
