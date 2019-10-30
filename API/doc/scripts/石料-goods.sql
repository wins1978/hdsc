-- 石料
CREATE TABLE `goods` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `goods_name` varchar(100) NOT NULL COMMENT '货物名称',
  `goods_alias` varchar(100) DEFAULT NULL COMMENT '货物别名',
  `group_name` varchar(100) NOT NULL COMMENT '大类:石仔、石粉',
  `order_index` int(11) NOT NULL COMMENT '排序',
  PRIMARY KEY (`id`),
  UNIQUE KEY `goods_idx1` (`goods_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8