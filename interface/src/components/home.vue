<template>
  <section class="home-hero">
    <div class="hero-content">
      <h1>Chào mừng đến với TuTai Spa</h1>
      <p>
        Thư giãn và chăm sóc sắc đẹp với đội ngũ chuyên nghiệp của chúng tôi.
      </p>
      <button @click="goToBooking" class="btn btn-primary">
        Đặt lịch ngay
      </button>
    </div>
  </section>

  <section class="services">
    <h2>Dịch vụ nổi bật</h2>
    <div class="service-list">
      <div class="service-item" v-for="service in services" :key="service.id">
        <img :src="service.image" :alt="service.name" />
        <h3>{{ service.name }}</h3>
        <p>{{ service.description }}</p>
      </div>
    </div>
  </section>

  <section class="about">
    <h2>Về TuTai Spa</h2>
    <p>
      TuTai Spa cam kết mang đến cho bạn trải nghiệm thư giãn và làm đẹp tốt
      nhất với công nghệ hiện đại và nhân viên tận tâm.
    </p>
  </section>
</template>

<script setup>
import { useRouter } from "vue-router";

const router = useRouter();

const services = [
  {
    id: 1,
    name: "Massage thư giãn",
    description: "Giúp cơ thể bạn được thư giãn và giảm căng thẳng hiệu quả.",
    image: "/images/massage.jpg",
  },
  {
    id: 2,
    name: "Chăm sóc da mặt",
    description: "Phục hồi và làm sáng da với liệu trình chuyên sâu.",
    image: "/images/skincare.jpg",
  },
  {
    id: 3,
    name: "Tắm trắng",
    description: "Dưỡng da trắng sáng tự nhiên và an toàn.",
    image: "/images/body-whitening.jpg",
  },
];

function goToBooking() {
  router.push("/dat-lich");
}
</script>

<style scoped>
.home-hero {
  background: url("/images/spa-hero.jpg") center center/cover no-repeat;
  color: white;
  text-align: center;
  padding: 120px 20px;
}

.hero-content h1 {
  font-size: 3rem;
  margin-bottom: 1rem;
}

.hero-content p {
  font-size: 1.2rem;
  margin-bottom: 2rem;
}

.services {
  padding: 50px 20px;
  background: #f9f9f9;
  text-align: center;
}

.service-list {
  display: flex;
  justify-content: center;
  gap: 30px;
  flex-wrap: wrap;
}

.service-item {
  background: white;
  border-radius: 10px;
  box-shadow: 0 0 12px rgb(0 0 0 / 0.1);
  max-width: 300px;
  padding: 20px;
}

.service-item img {
  width: 100%;
  border-radius: 8px;
  margin-bottom: 15px;
}

.about {
  padding: 40px 20px;
  max-width: 800px;
  margin: 0 auto;
  font-size: 1.1rem;
  text-align: center;
}
</style>
