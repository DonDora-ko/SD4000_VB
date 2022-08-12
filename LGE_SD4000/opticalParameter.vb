﻿Module opticalParameter
    'all spectrum start from 380 nm end 780 nm
    '행렬은....  상수선언 못하는가??????
    Public Const K_10deg_D65 As Single = 0.04302773
    Public Const K_2deg_D65 As Single = 0.04731588
    Public Const K_10deg_C As Single = 0.0425601
    Public Const K_2deg_C As Single = 0.04696205

    Public Const Xn_10deg_D65 As Single = 94.81181
    Public Const Yn_10deg_D65 As Single = 100.0
    Public Const Zn_10deg_D65 As Single = 107.3241
    Public Const Xn_2deg_D65 As Single = 95.04298
    Public Const Yn_2deg_D65 As Single = 100.0
    Public Const Zn_2deg_D65 As Single = 108.8801
    Public Const Xn_10deg_C As Single = 97.28502
    Public Const Yn_10deg_C As Single = 100
    Public Const Zn_10deg_C As Single = 116.1445
    Public Const Xn_2deg_C As Single = 98.07175
    Public Const Yn_2deg_C As Single =100
    Public Const Zn_2deg_C As Single = 118.2249

    Public D65_5nm() As Single = {49.9755, 52.3118, 54.6482, 68.7015, 82.7549, 87.1204, 91.486, 92.4589, 93.4318, 90.057, 86.6823, 95.7736, 104.865, 110.936, 117.008, 117.41, 117.812, 116.336, 114.861, 115.392, 115.923, 112.367, 108.811, 109.082, 109.354, 108.578, 107.802, 106.296, 104.79, 106.239, 107.689, 106.047, 104.405, 104.225, 104.046, 102.023, 100, 98.1671, 96.3342, 96.0611, 95.788, 92.2368, 88.6856, 89.3459, 90.0062, 89.8026, 89.5991, 88.6489, 87.6987, 85.4936, 83.2886, 83.4939, 83.6992, 81.863, 80.0268, 80.1207, 80.2146, 81.2462, 82.2778, 80.281, 78.2842, 74.0027, 69.7213, 70.6652, 71.6091, 72.979, 74.349, 67.9765, 61.604, 65.7448, 69.8856, 72.4863, 75.087, 69.3398, 63.5927, 55.0054, 46.4182, 56.6118, 66.8054, 65.0941, 63.3828}
    Public D65_1nm() As Single = {49.9755, 50.4428, 50.91, 51.3773, 51.8446, 52.3118, 52.7791, 53.2464, 53.7137, 54.1809, 54.6482, 57.4589, 60.2695, 63.0802, 65.8909, 68.7015, 71.5122, 74.3229, 77.1336, 79.9442, 82.7549, 83.628, 84.5011, 85.3742, 86.2473, 87.1204, 87.9936, 88.8667, 89.7398, 90.6129, 91.486, 91.6806, 91.8752, 92.0697, 92.2643, 92.4589, 92.6535, 92.8481, 93.0426, 93.2372, 93.4318, 92.7568, 92.0819, 91.4069, 90.732, 90.057, 89.3821, 88.7071, 88.0322, 87.3572, 86.6823, 88.5006, 90.3188, 92.1371, 93.9554, 95.7736, 97.5919, 99.4102, 101.228, 103.047, 104.865, 106.079, 107.294, 108.508, 109.722, 110.936, 112.151, 113.365, 114.579, 115.794, 117.008, 117.088, 117.169, 117.249, 117.33, 117.41, 117.49, 117.571, 117.651, 117.732, 117.812, 117.517, 117.222, 116.927, 116.632, 116.336, 116.041, 115.746, 115.451, 115.156, 114.861, 114.967, 115.073, 115.18, 115.286, 115.392, 115.498, 115.604, 115.711, 115.817, 115.923, 115.212, 114.501, 113.789, 113.078, 112.367, 111.656, 110.945, 110.233, 109.522, 108.811, 108.865, 108.92, 108.974, 109.028, 109.082, 109.137, 109.191, 109.245, 109.3, 109.354, 109.199, 109.044, 108.888, 108.733, 108.578, 108.423, 108.268, 108.112, 107.957, 107.802, 107.501, 107.2, 106.898, 106.597, 106.296, 105.995, 105.694, 105.392, 105.091, 104.79, 105.08, 105.37, 105.66, 105.95, 106.239, 106.529, 106.819, 107.109, 107.399, 107.689, 107.361, 107.032, 106.704, 106.375, 106.047, 105.719, 105.39, 105.062, 104.733, 104.405, 104.369, 104.333, 104.297, 104.261, 104.225, 104.19, 104.154, 104.118, 104.082, 104.046, 103.641, 103.237, 102.832, 102.428, 102.023, 101.618, 101.214, 100.809, 100.405, 100, 99.6334, 99.2668, 98.9003, 98.5337, 98.1671, 97.8005, 97.4339, 97.0674, 96.7008, 96.3342, 96.2796, 96.225, 96.1703, 96.1157, 96.0611, 96.0065, 95.9519, 95.8972, 95.8426, 95.788, 95.0778, 94.3675, 93.6573, 92.947, 92.2368, 91.5266, 90.8163, 90.1061, 89.3958, 88.6856, 88.8177, 88.9497, 89.0818, 89.2138, 89.3459, 89.478, 89.61, 89.7421, 89.8741, 90.0062, 89.9655, 89.9248, 89.8841, 89.8434, 89.8026, 89.7619, 89.7212, 89.6805, 89.6398, 89.5991, 89.4091, 89.219, 89.029, 88.8389, 88.6489, 88.4589, 88.2688, 88.0788, 87.8887, 87.6987, 87.2577, 86.8167, 86.3757, 85.9347, 85.4936, 85.0526, 84.6116, 84.1706, 83.7296, 83.2886, 83.3297, 83.3707, 83.4118, 83.4528, 83.4939, 83.535, 83.576, 83.6171, 83.6581, 83.6992, 83.332, 82.9647, 82.5975, 82.2302, 81.863, 81.4958, 81.1285, 80.7613, 80.394, 80.0268, 80.0456, 80.0644, 80.0831, 80.1019, 80.1207, 80.1395, 80.1583, 80.177, 80.1958, 80.2146, 80.4209, 80.6272, 80.8336, 81.0399, 81.2462, 81.4525, 81.6588, 81.8652, 82.0715, 82.2778, 81.8784, 81.4791, 81.0797, 80.6804, 80.281, 79.8816, 79.4823, 79.0829, 78.6836, 78.2842, 77.4279, 76.5716, 75.7153, 74.859, 74.0027, 73.1465, 72.2902, 71.4339, 70.5776, 69.7213, 69.9101, 70.0989, 70.2876, 70.4764, 70.6652, 70.854, 71.0428, 71.2315, 71.4203, 71.6091, 71.8831, 72.1571, 72.4311, 72.7051, 72.979, 73.253, 73.527, 73.801, 74.075, 74.349, 73.0745, 71.8, 70.5255, 69.251, 67.9765, 66.702, 65.4275, 64.153, 62.8785, 61.604, 62.4322, 63.2603, 64.0885, 64.9166, 65.7448, 66.573, 67.4011, 68.2293, 69.0574, 69.8856, 70.4057, 70.9259, 71.446, 71.9662, 72.4863, 73.0064, 73.5266, 74.0467, 74.5669, 75.087, 73.9376, 72.7881, 71.6387, 70.4893, 69.3398, 68.1904, 67.041, 65.8916, 64.7421, 63.5927, 61.8752, 60.1578, 58.4403, 56.7229, 55.0054, 53.288, 51.5705, 49.8531, 48.1356, 46.4182, 48.4569, 50.4956, 52.5344, 54.5731, 56.6118, 58.6505, 60.6892, 62.728, 64.7667, 66.8054, 66.4631, 66.1209, 65.7786, 65.4364, 65.0941, 64.7518, 64.4096, 64.0673, 63.7251, 63.3828}

    Public C_5nm() As Single = {33, 39.92, 47.4, 55.17, 63.3, 71.81, 80.6, 89.53, 98.1, 105.8, 112.4, 117.75, 121.5, 123.45, 124, 123.6, 123.1, 123.3, 123.8, 124.09, 123.9, 122.92, 120.7, 116.9, 112.1, 106.98, 102.3, 98.81, 96.9, 96.78, 98, 99.94, 102.1, 103.95, 105.2, 105.67, 105.3, 104.11, 102.3, 100.15, 97.8, 95.43, 93.2, 91.22, 89.7, 88.83, 88.4, 88.19, 88.1, 88.06, 88, 87.86, 87.8, 87.99, 88.2, 88.2, 87.9, 87.22, 86.3, 85.3, 84, 82.21, 80.2, 78.24, 76.3, 74.36, 72.4, 70.4, 68.3, 66.3, 64.4, 62.8, 61.5, 60.2, 59.2, 58.5, 58.1, 58, 58.2, 58.5, 59.1}

    Public CMF_x_bar_2deg_5nm() As Single = {0.00137, 0.00224, 0.00424, 0.00765, 0.01431, 0.02319, 0.04351, 0.07763, 0.13438, 0.21477, 0.2839, 0.3285, 0.34828, 0.34806, 0.3362, 0.3187, 0.2908, 0.2511, 0.19536, 0.1421, 0.09564, 0.05795, 0.03201, 0.0147, 0.0049, 0.0024, 0.0093, 0.0291, 0.06327, 0.1096, 0.1655, 0.22575, 0.2904, 0.3597, 0.43345, 0.51205, 0.5945, 0.6784, 0.7621, 0.8425, 0.9163, 0.9786, 1.0263, 1.0567, 1.0622, 1.0456, 1.0026, 0.9384, 0.85445, 0.7514, 0.6424, 0.5419, 0.4479, 0.3608, 0.2835, 0.2187, 0.1649, 0.1212, 0.0874, 0.0636, 0.04677, 0.0329, 0.0227, 0.01584, 0.01136, 0.00811, 0.00579, 0.00411, 0.0029, 0.00205, 0.00144, 0.000999949, 0.000690079, 0.000476021, 0.000332301, 0.000234826, 0.000166151, 0.000117413, 0.0000830753, 0.0000587065, 0.0000415099}
    Public CMF_y_bar_2deg_5nm() As Single = {0.000039, 0.000064, 0.00012, 0.000217, 0.000396, 0.00064, 0.00121, 0.00218, 0.004, 0.0073, 0.0116, 0.01684, 0.023, 0.0298, 0.038, 0.048, 0.06, 0.0739, 0.09098, 0.1126, 0.13902, 0.1693, 0.20802, 0.2586, 0.323, 0.4073, 0.503, 0.6082, 0.71, 0.7932, 0.862, 0.91485, 0.954, 0.9803, 0.99495, 1, 0.995, 0.9786, 0.952, 0.9154, 0.87, 0.8163, 0.757, 0.6949, 0.631, 0.5668, 0.503, 0.4412, 0.381, 0.321, 0.265, 0.217, 0.175, 0.1382, 0.107, 0.0816, 0.061, 0.04458, 0.032, 0.0232, 0.017, 0.01192, 0.00821, 0.00572, 0.0041, 0.00293, 0.00209, 0.00148, 0.00105, 0.00074, 0.00052, 0.0003611, 0.0002492, 0.0001719, 0.00012, 0.0000848, 0.00006, 0.0000424, 0.00003, 0.0000212, 0.00001499}
    Public CMF_z_bar_2deg_5nm() As Single = {0.00645, 0.01055, 0.02005, 0.03621, 0.06785, 0.1102, 0.2074, 0.3713, 0.6456, 1.03905, 1.3856, 1.62296, 1.74706, 1.7826, 1.77211, 1.7441, 1.6692, 1.5281, 1.28764, 1.0419, 0.81295, 0.6162, 0.46518, 0.3533, 0.272, 0.2123, 0.1582, 0.1117, 0.07825, 0.05725, 0.04216, 0.02984, 0.0203, 0.0134, 0.00875, 0.00575, 0.0039, 0.00275, 0.0021, 0.0018, 0.00165, 0.0014, 0.0011, 0.001, 0.0008, 0.0006, 0.00034, 0.00024, 0.00019, 0.0001, 0.00005, 0.00003, 0.00002, 0.00001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    Public CMF_x_bar_2deg_1nm() As Single = {0.00137, 0.00154, 0.00172, 0.00189, 0.00206, 0.00224, 0.00264, 0.00304, 0.00344, 0.00384, 0.00424, 0.00492, 0.00561, 0.00629, 0.00697, 0.00765, 0.00898, 0.01031, 0.01165, 0.01298, 0.01431, 0.01609, 0.01786, 0.01964, 0.02141, 0.02319, 0.02725, 0.03132, 0.03538, 0.03945, 0.04351, 0.05033, 0.05716, 0.06398, 0.07081, 0.07763, 0.08898, 0.10033, 0.11168, 0.12303, 0.13438, 0.15046, 0.16654, 0.18261, 0.19869, 0.21477, 0.2286, 0.24242, 0.25625, 0.27007, 0.2839, 0.29282, 0.30174, 0.31066, 0.31958, 0.3285, 0.33246, 0.33641, 0.34037, 0.34432, 0.34828, 0.34824, 0.34819, 0.34815, 0.3481, 0.34806, 0.34569, 0.34332, 0.34094, 0.33857, 0.3362, 0.3327, 0.3292, 0.3257, 0.3222, 0.3187, 0.31312, 0.30754, 0.30196, 0.29638, 0.2908, 0.28286, 0.27492, 0.26698, 0.25904, 0.2511, 0.23995, 0.2288, 0.21766, 0.20651, 0.19536, 0.18471, 0.17406, 0.1634, 0.15275, 0.1421, 0.13281, 0.12352, 0.11422, 0.10493, 0.09564, 0.0881, 0.08056, 0.07303, 0.06549, 0.05795, 0.05276, 0.04757, 0.04239, 0.0372, 0.03201, 0.02855, 0.02509, 0.02162, 0.01816, 0.0147, 0.01274, 0.01078, 0.00882, 0.00686, 0.0049, 0.0044, 0.0039, 0.0034, 0.0029, 0.0024, 0.00378, 0.00516, 0.00654, 0.00792, 0.0093, 0.01326, 0.01722, 0.02118, 0.02514, 0.0291, 0.03593, 0.04277, 0.0496, 0.05644, 0.06327, 0.07254, 0.0818, 0.09107, 0.10033, 0.1096, 0.12078, 0.13196, 0.14314, 0.15432, 0.1655, 0.17755, 0.1896, 0.20165, 0.2137, 0.22575, 0.23868, 0.25161, 0.26454, 0.27747, 0.2904, 0.30426, 0.31812, 0.33198, 0.34584, 0.3597, 0.37445, 0.3892, 0.40395, 0.4187, 0.43345, 0.44917, 0.46489, 0.48061, 0.49633, 0.51205, 0.52854, 0.54503, 0.56152, 0.57801, 0.5945, 0.61128, 0.62806, 0.64484, 0.66162, 0.6784, 0.69514, 0.71188, 0.72862, 0.74536, 0.7621, 0.77818, 0.79426, 0.81034, 0.82642, 0.8425, 0.85726, 0.87202, 0.88678, 0.90154, 0.9163, 0.92876, 0.94122, 0.95368, 0.96614, 0.9786, 0.98814, 0.99768, 1.00722, 1.01676, 1.0263, 1.03238, 1.03846, 1.04454, 1.05062, 1.0567, 1.0578, 1.0589, 1.06, 1.0611, 1.0622, 1.05888, 1.05556, 1.05224, 1.04892, 1.0456, 1.037, 1.0284, 1.0198, 1.0112, 1.0026, 0.98976, 0.97692, 0.96408, 0.95124, 0.9384, 0.92161, 0.90482, 0.88803, 0.87124, 0.85445, 0.83384, 0.81323, 0.79262, 0.77201, 0.7514, 0.7296, 0.7078, 0.686, 0.6642, 0.6424, 0.6223, 0.6022, 0.5821, 0.562, 0.5419, 0.5231, 0.5043, 0.4855, 0.4667, 0.4479, 0.43048, 0.41306, 0.39564, 0.37822, 0.3608, 0.34534, 0.32988, 0.31442, 0.29896, 0.2835, 0.27054, 0.25758, 0.24462, 0.23166, 0.2187, 0.20794, 0.19718, 0.18642, 0.17566, 0.1649, 0.15616, 0.14742, 0.13868, 0.12994, 0.1212, 0.11444, 0.10768, 0.10092, 0.09416, 0.0874, 0.08264, 0.07788, 0.07312, 0.06836, 0.0636, 0.06023, 0.05687, 0.0535, 0.05014, 0.04677, 0.044, 0.04122, 0.03845, 0.03567, 0.0329, 0.03086, 0.02882, 0.02678, 0.02474, 0.0227, 0.02133, 0.01996, 0.01858, 0.01721, 0.01584, 0.01494, 0.01405, 0.01315, 0.01226, 0.01136, 0.01071, 0.01006, 0.00941, 0.00876, 0.00811, 0.00765, 0.00718, 0.00672, 0.00625, 0.00579, 0.00545, 0.00512, 0.00478, 0.00444, 0.00411, 0.00387, 0.00362, 0.00338, 0.00314, 0.0029, 0.00273, 0.00256, 0.00239, 0.00222, 0.00205, 0.00193, 0.00181, 0.00168, 0.00156, 0.00144, 0.00135, 0.00126, 0.00118, 0.00109, 0.000999949, 0.000937975, 0.000876001, 0.000814027, 0.000752053, 0.000690079, 0.000647267, 0.000604456, 0.000561644, 0.000518833, 0.000476021, 0.000447277, 0.000418533, 0.000389789, 0.000361045, 0.000332301, 0.000312806, 0.000293311, 0.000273816, 0.000254321, 0.000234826, 0.000221091, 0.000207356, 0.000193621, 0.000179886, 0.000166151, 0.000156403, 0.000146656, 0.000136908, 0.000127161, 0.000117413, 0.000110545, 0.000103678, 0.0000968104, 0.0000899428, 0.0000830753, 0.0000782015, 0.0000733278, 0.000068454, 0.0000635803, 0.0000587065, 0.0000552672, 0.0000518279, 0.0000483885, 0.0000449492, 0.0000415099}
    Public CMF_y_bar_2deg_1nm() As Single = {0.000039, 0.000044, 0.000049, 0.000054, 0.000059, 0.000064, 0.0000752, 0.0000864, 0.0000976, 0.0001088, 0.00012, 0.0001394, 0.0001588, 0.0001782, 0.0001976, 0.000217, 0.0002528, 0.0002886, 0.0003244, 0.0003602, 0.000396, 0.0004448, 0.0004936, 0.0005424, 0.0005912, 0.00064, 0.000754, 0.000868, 0.000982, 0.0011, 0.00121, 0.0014, 0.0016, 0.00179, 0.00199, 0.00218, 0.00254, 0.00291, 0.00327, 0.00364, 0.004, 0.00466, 0.00532, 0.00598, 0.00664, 0.0073, 0.00816, 0.00902, 0.00988, 0.01074, 0.0116, 0.01265, 0.0137, 0.01474, 0.01579, 0.01684, 0.01807, 0.0193, 0.02054, 0.02177, 0.023, 0.02436, 0.02572, 0.02708, 0.02844, 0.0298, 0.03144, 0.03308, 0.03472, 0.03636, 0.038, 0.04, 0.042, 0.044, 0.046, 0.048, 0.0504, 0.0528, 0.0552, 0.0576, 0.06, 0.06278, 0.06556, 0.06834, 0.07112, 0.0739, 0.07732, 0.08073, 0.08415, 0.08756, 0.09098, 0.0953, 0.09963, 0.10395, 0.10828, 0.1126, 0.11788, 0.12317, 0.12845, 0.13374, 0.13902, 0.14508, 0.15113, 0.15719, 0.16324, 0.1693, 0.17704, 0.18479, 0.19253, 0.20028, 0.20802, 0.21814, 0.22825, 0.23837, 0.24848, 0.2586, 0.27148, 0.28436, 0.29724, 0.31012, 0.323, 0.33986, 0.35672, 0.37358, 0.39044, 0.4073, 0.42644, 0.44558, 0.46472, 0.48386, 0.503, 0.52404, 0.54508, 0.56612, 0.58716, 0.6082, 0.62856, 0.64892, 0.66928, 0.68964, 0.71, 0.72664, 0.74328, 0.75992, 0.77656, 0.7932, 0.80696, 0.82072, 0.83448, 0.84824, 0.862, 0.87257, 0.88314, 0.89371, 0.90428, 0.91485, 0.92268, 0.93051, 0.93834, 0.94617, 0.954, 0.95926, 0.96452, 0.96978, 0.97504, 0.9803, 0.98323, 0.98616, 0.98909, 0.99202, 0.99495, 0.99596, 0.99697, 0.99798, 0.99899, 1, 0.999, 0.998, 0.997, 0.996, 0.995, 0.99172, 0.98844, 0.98516, 0.98188, 0.9786, 0.97328, 0.96796, 0.96264, 0.95732, 0.952, 0.94468, 0.93736, 0.93004, 0.92272, 0.9154, 0.90632, 0.89724, 0.88816, 0.87908, 0.87, 0.85926, 0.84852, 0.83778, 0.82704, 0.8163, 0.80444, 0.79258, 0.78072, 0.76886, 0.757, 0.74458, 0.73216, 0.71974, 0.70732, 0.6949, 0.68212, 0.66934, 0.65656, 0.64378, 0.631, 0.61816, 0.60532, 0.59248, 0.57964, 0.5668, 0.55404, 0.54128, 0.52852, 0.51576, 0.503, 0.49064, 0.47828, 0.46592, 0.45356, 0.4412, 0.42916, 0.41712, 0.40508, 0.39304, 0.381, 0.369, 0.357, 0.345, 0.333, 0.321, 0.3098, 0.2986, 0.2874, 0.2762, 0.265, 0.2554, 0.2458, 0.2362, 0.2266, 0.217, 0.2086, 0.2002, 0.1918, 0.1834, 0.175, 0.16764, 0.16028, 0.15292, 0.14556, 0.1382, 0.13196, 0.12572, 0.11948, 0.11324, 0.107, 0.10192, 0.09684, 0.09176, 0.08668, 0.0816, 0.07748, 0.07336, 0.06924, 0.06512, 0.061, 0.05772, 0.05443, 0.05115, 0.04786, 0.04458, 0.04206, 0.03955, 0.03703, 0.03452, 0.032, 0.03024, 0.02848, 0.02672, 0.02496, 0.0232, 0.02196, 0.02072, 0.01948, 0.01824, 0.017, 0.01598, 0.01497, 0.01395, 0.01294, 0.01192, 0.01118, 0.01044, 0.00969, 0.00895, 0.00821, 0.00771, 0.00722, 0.00672, 0.00622, 0.00572, 0.0054, 0.00507, 0.00475, 0.00443, 0.0041, 0.00387, 0.00363, 0.0034, 0.00316, 0.00293, 0.00276, 0.00259, 0.00243, 0.00226, 0.00209, 0.00197, 0.00185, 0.00173, 0.00161, 0.00148, 0.0014, 0.00131, 0.00122, 0.00113, 0.00105, 0.0009856, 0.0009242, 0.0008628, 0.0008014, 0.00074, 0.000696, 0.000652, 0.000608, 0.000564, 0.00052, 0.00048822, 0.00045644, 0.00042466, 0.00039288, 0.0003611, 0.00033872, 0.00031634, 0.00029396, 0.00027158, 0.0002492, 0.00023374, 0.00021828, 0.00020282, 0.00018736, 0.0001719, 0.00016152, 0.00015114, 0.00014076, 0.00013038, 0.00012, 0.00011296, 0.00010592, 0.00009888, 0.00009184, 0.0000848, 0.00007984, 0.00007488, 0.00006992, 0.00006496, 0.00006, 0.00005648, 0.00005296, 0.00004944, 0.00004592, 0.0000424, 0.00003992, 0.00003744, 0.00003496, 0.00003248, 0.00003, 0.00002824, 0.00002648, 0.00002472, 0.00002296, 0.0000212, 0.000019958, 0.000018716, 0.000017474, 0.000016232, 0.00001499}
    Public CMF_z_bar_2deg_1nm() As Single = {0.00645, 0.00727, 0.00809, 0.00891, 0.00973, 0.01055, 0.01245, 0.01435, 0.01625, 0.01815, 0.02005, 0.02328, 0.02651, 0.02975, 0.03298, 0.03621, 0.04254, 0.04887, 0.05519, 0.06152, 0.06785, 0.07632, 0.08479, 0.09326, 0.10173, 0.1102, 0.12964, 0.14908, 0.16852, 0.18796, 0.2074, 0.24018, 0.27296, 0.30574, 0.33852, 0.3713, 0.42616, 0.48102, 0.53588, 0.59074, 0.6456, 0.72429, 0.80298, 0.88167, 0.96036, 1.03905, 1.10836, 1.17767, 1.24698, 1.31629, 1.3856, 1.43307, 1.48054, 1.52802, 1.57549, 1.62296, 1.64778, 1.6726, 1.69742, 1.72224, 1.74706, 1.75417, 1.76128, 1.76838, 1.77549, 1.7826, 1.7805, 1.7784, 1.77631, 1.77421, 1.77211, 1.76651, 1.76091, 1.7553, 1.7497, 1.7441, 1.72912, 1.71414, 1.69916, 1.68418, 1.6692, 1.64098, 1.61276, 1.58454, 1.55632, 1.5281, 1.48001, 1.43192, 1.38382, 1.33573, 1.28764, 1.23849, 1.18934, 1.1402, 1.09105, 1.0419, 0.99611, 0.95032, 0.90453, 0.85874, 0.81295, 0.7736, 0.73425, 0.6949, 0.65555, 0.6162, 0.586, 0.55579, 0.52559, 0.49538, 0.46518, 0.4428, 0.42043, 0.39805, 0.37568, 0.3533, 0.33704, 0.32078, 0.30452, 0.28826, 0.272, 0.26006, 0.24812, 0.23618, 0.22424, 0.2123, 0.20148, 0.19066, 0.17984, 0.16902, 0.1582, 0.1489, 0.1396, 0.1303, 0.121, 0.1117, 0.10501, 0.09832, 0.09163, 0.08494, 0.07825, 0.07405, 0.06985, 0.06565, 0.06145, 0.05725, 0.05423, 0.05121, 0.0482, 0.04518, 0.04216, 0.0397, 0.03723, 0.03477, 0.0323, 0.02984, 0.02793, 0.02602, 0.02412, 0.02221, 0.0203, 0.01892, 0.01754, 0.01616, 0.01478, 0.0134, 0.01247, 0.01154, 0.01061, 0.00968, 0.00875, 0.00815, 0.00755, 0.00695, 0.00635, 0.00575, 0.00538, 0.00501, 0.00464, 0.00427, 0.0039, 0.00367, 0.00344, 0.00321, 0.00298, 0.00275, 0.00262, 0.00249, 0.00236, 0.00223, 0.0021, 0.00204, 0.00198, 0.00192, 0.00186, 0.0018, 0.00177, 0.00174, 0.00171, 0.00168, 0.00165, 0.0016, 0.00155, 0.0015, 0.00145, 0.0014, 0.00134, 0.00128, 0.00122, 0.00116, 0.0011, 0.00108, 0.00106, 0.00104, 0.00102, 0.001, 0.00096, 0.00092, 0.00088, 0.00084, 0.0008, 0.00076, 0.00072, 0.00068, 0.00064, 0.0006, 0.000548, 0.000496, 0.000444, 0.000392, 0.00034, 0.00032, 0.0003, 0.00028, 0.00026, 0.00024, 0.00023, 0.00022, 0.00021, 0.0002, 0.00019, 0.000172, 0.000154, 0.000136, 0.000118, 0.0001, 0.00009, 0.00008, 0.00007, 0.00006, 0.00005, 0.000046, 0.000042, 0.000038, 0.000034, 0.00003, 0.000028, 0.000026, 0.000024, 0.000022, 0.00002, 0.000018, 0.000016, 0.000014, 0.000012, 0.00001, 0.000008, 0.000006, 0.000004, 0.000002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    Public CMF_x_bar_10deg_5nm() As Single = {0.00016, 0.000662, 0.002362, 0.007242, 0.01911, 0.0434, 0.084736, 0.140638, 0.204492, 0.264737, 0.314679, 0.357719, 0.383734, 0.386726, 0.370702, 0.342957, 0.302273, 0.254085, 0.195618, 0.132349, 0.080507, 0.041072, 0.016172, 0.005132, 0.003816, 0.015444, 0.037465, 0.071358, 0.117749, 0.172953, 0.236491, 0.304213, 0.376772, 0.451584, 0.529826, 0.616053, 0.705224, 0.793832, 0.878655, 0.951162, 1.01416, 1.0743, 1.11852, 1.1343, 1.12399, 1.0891, 1.03048, 0.95074, 0.856297, 0.75493, 0.647467, 0.53511, 0.431567, 0.34369, 0.268329, 0.2043, 0.152568, 0.11221, 0.081261, 0.05793, 0.040851, 0.028623, 0.019941, 0.013842, 0.009577, 0.006605, 0.004553, 0.003145, 0.002175, 0.001506, 0.001045, 0.000727, 0.000508, 0.000356, 0.000251, 0.000178, 0.000126, 0.00009, 0.000065, 0.000046, 0.000033}
    Public CMF_y_bar_10deg_5nm() As Single = {0.000017, 0.000072, 0.000253, 0.000769, 0.002004, 0.004509, 0.008756, 0.014456, 0.021391, 0.029497, 0.038676, 0.049602, 0.062077, 0.074704, 0.089456, 0.106256, 0.128201, 0.152761, 0.18519, 0.21994, 0.253589, 0.297665, 0.339133, 0.395379, 0.460777, 0.53136, 0.606741, 0.68566, 0.761757, 0.82333, 0.875211, 0.92381, 0.961988, 0.9822, 0.991761, 0.99911, 0.99734, 0.98238, 0.955552, 0.915175, 0.868934, 0.825623, 0.777405, 0.720353, 0.658341, 0.593878, 0.527963, 0.461834, 0.398057, 0.339554, 0.283493, 0.228254, 0.179828, 0.140211, 0.107633, 0.081187, 0.060281, 0.044096, 0.0318, 0.022602, 0.015905, 0.01113, 0.007749, 0.005375, 0.003718, 0.002565, 0.001768, 0.001222, 0.000846, 0.000586, 0.000407, 0.000284, 0.000199, 0.00014, 0.000098, 0.00007, 0.00005, 0.000036, 0.000025, 0.000018, 0.000013}
    Public CMF_z_bar_10deg_5nm() As Single = {0.000705, 0.002928, 0.010482, 0.032344, 0.086011, 0.19712, 0.389366, 0.65676, 0.972542, 1.2825, 1.55348, 1.7985, 1.96728, 2.0273, 1.9948, 1.9007, 1.74537, 1.5549, 1.31756, 1.0302, 0.772125, 0.57006, 0.415254, 0.302356, 0.218502, 0.159249, 0.112044, 0.082248, 0.060709, 0.04305, 0.030451, 0.020584, 0.013676, 0.007918, 0.003988, 0.001091, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}

    'Public CMF_x_bar_10deg_1nm() As Double = {}
    'Public CMF_y_bar_10deg_1nm() As Double = {}
    'Public CMF_z_bar_10deg_1nm() As Double = {}

    Public wavelength_1nm() As Integer = {380, 381, 382, 383, 384, 385, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 428, 429, 430, 431, 432, 433, 434, 435, 436, 437, 438, 439, 440, 441, 442, 443, 444, 445, 446, 447, 448, 449, 450, 451, 452, 453, 454, 455, 456, 457, 458, 459, 460, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471, 472, 473, 474, 475, 476, 477, 478, 479, 480, 481, 482, 483, 484, 485, 486, 487, 488, 489, 490, 491, 492, 493, 494, 495, 496, 497, 498, 499, 500, 501, 502, 503, 504, 505, 506, 507, 508, 509, 510, 511, 512, 513, 514, 515, 516, 517, 518, 519, 520, 521, 522, 523, 524, 525, 526, 527, 528, 529, 530, 531, 532, 533, 534, 535, 536, 537, 538, 539, 540, 541, 542, 543, 544, 545, 546, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 567, 568, 569, 570, 571, 572, 573, 574, 575, 576, 577, 578, 579, 580, 581, 582, 583, 584, 585, 586, 587, 588, 589, 590, 591, 592, 593, 594, 595, 596, 597, 598, 599, 600, 601, 602, 603, 604, 605, 606, 607, 608, 609, 610, 611, 612, 613, 614, 615, 616, 617, 618, 619, 620, 621, 622, 623, 624, 625, 626, 627, 628, 629, 630, 631, 632, 633, 634, 635, 636, 637, 638, 639, 640, 641, 642, 643, 644, 645, 646, 647, 648, 649, 650, 651, 652, 653, 654, 655, 656, 657, 658, 659, 660, 661, 662, 663, 664, 665, 666, 667, 668, 669, 670, 671, 672, 673, 674, 675, 676, 677, 678, 679, 680, 681, 682, 683, 684, 685, 686, 687, 688, 689, 690, 691, 692, 693, 694, 695, 696, 697, 698, 699, 700, 701, 702, 703, 704, 705, 706, 707, 708, 709, 710, 711, 712, 713, 714, 715, 716, 717, 718, 719, 720, 721, 722, 723, 724, 725, 726, 727, 728, 729, 730, 731, 732, 733, 734, 735, 736, 737, 738, 739, 740, 741, 742, 743, 744, 745, 746, 747, 748, 749, 750, 751, 752, 753, 754, 755, 756, 757, 758, 759, 760, 761, 762, 763, 764, 765, 766, 767, 768, 769, 770, 771, 772, 773, 774, 775, 776, 777, 778, 779, 780}
    Public wavelength_5nm() As Integer = {380, 385, 390, 395, 400, 405, 410, 415, 420, 425, 430, 435, 440, 445, 450, 455, 460, 465, 470, 475, 480, 485, 490, 495, 500, 505, 510, 515, 520, 525, 530, 535, 540, 545, 550, 555, 560, 565, 570, 575, 580, 585, 590, 595, 600, 605, 610, 615, 620, 625, 630, 635, 640, 645, 650, 655, 660, 665, 670, 675, 680, 685, 690, 695, 700, 705, 710, 715, 720, 725, 730, 735, 740, 745, 750, 755, 760, 765, 770, 775, 780}
    Public Function calculate_uvPrime(XYZarray() As Single) As Single()
        Dim u_prime, v_prime As Single
        Dim retArray(1) As Single
        Dim X, Y, Z As Single
        X = XYZarray(0)
        Y = XYZarray(1)
        Z = XYZarray(2)

        Try
            u_prime = (4 * X) / (X + 15 * Y + 3 * Z)
            v_prime = (9 * Y) / (X + 15 * Y + 3 * Z)

            retArray(0) = u_prime
            retArray(1) = v_prime
        Catch ex As Exception
            Return Nothing
            Exit Function
        End Try

        Return retArray
    End Function
    Public Function calculate_K10_D65() As Single
        Dim i As Integer
        Dim sumtemp As Single
        Dim retValue As Single

        sumtemp = 0
        If UBound(CMF_y_bar_10deg_5nm) = UBound(D65_5nm) Then
            For i = 0 To UBound(D65_5nm)
                sumtemp += CMF_y_bar_10deg_5nm(i) * D65_5nm(i)
            Next i

            retValue = 100.0 / sumtemp
            ' Debug.Print("K10_D65 : " & retValue)
            Return retValue
        Else
            MsgBox("while calculating K10_D65, array count error")
            Return Nothing
        End If
    End Function

    Public Function calculate_K2_D65() As Single
        Dim i As Integer
        Dim sumtemp As Single
        Dim retValue As Single

        sumtemp = 0
        If UBound(CMF_y_bar_2deg_5nm) = UBound(D65_5nm) Then
            For i = 0 To UBound(D65_5nm)
                sumtemp += CMF_y_bar_2deg_5nm(i) * D65_5nm(i)
            Next i

            retValue = 100.0 / sumtemp
            'Debug.Print("K2_D65 : " & retValue)
            Return retValue
        Else
            MsgBox("while calculating K2_D65, array count error")
            Return Nothing
        End If
    End Function
    Public Function calculate_K2_C() As Single
        Dim i As Integer
        Dim sumtemp As Single
        Dim retValue As Single
        sumtemp = 0
        If UBound(CMF_y_bar_2deg_5nm) = UBound(C_5nm) Then
            For i = 0 To UBound(C_5nm)
                sumtemp += CMF_y_bar_2deg_5nm(i) * C_5nm(i)
            Next i

            retValue = 100.0 / sumtemp
            ' Debug.Print("K2_C : " & retValue)


            Return retValue

        Else
            MsgBox("while calculating K2_C, array count error")
            Return Nothing
        End If
    End Function
    Public Function calculate_K10_C() As Single
        Dim i As Integer
        Dim sumtemp As Single
        Dim retValue As Single
        sumtemp = 0
        If UBound(CMF_y_bar_10deg_5nm) = UBound(C_5nm) Then
            For i = 0 To UBound(C_5nm)
                sumtemp += CMF_y_bar_10deg_5nm(i) * C_5nm(i)
            Next i

            retValue = 100.0 / sumtemp
            'Debug.Print("K10_C : " & retValue)


            Return retValue

        Else
            MsgBox("while calculating K10_C, array count error")
            Return Nothing
        End If
    End Function

    Public Function calculate_XYZ(measuredSpectrum() As Single, degree As String, lightsource As String) As Single()
        Dim i As Integer
        Dim a As Integer
        Dim retArray(2) As Single

        a = UBound(measuredSpectrum)
        Dim largeX, largeY, largeZ As Single
        largeX = 0
        largeY = 0
        largeZ = 0

        ' Debug.Print("in optical parameter: " & degree)
        'Debug.Print("in optical parameter: " & lightsource)

        If a = Form_Main.spectrumCount - 1 Then

            If degree = "2 Degree" Then  '2 Degree or 10 Degree
                If lightsource = "D65" Then
                    For i = 0 To UBound(measuredSpectrum)
                        largeX += D65_5nm(i) * CMF_x_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeY += D65_5nm(i) * CMF_y_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeZ += D65_5nm(i) * CMF_z_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                    Next

                    largeX = largeX * K_2deg_D65
                    largeY = largeY * K_2deg_D65
                    largeZ = largeZ * K_2deg_D65
                ElseIf lightsource = "C" Then
                    For i = 0 To UBound(measuredSpectrum)
                        largeX += C_5nm(i) * CMF_x_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeY += C_5nm(i) * CMF_y_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeZ += C_5nm(i) * CMF_z_bar_2deg_5nm(i) * measuredSpectrum(i) / 100.0
                    Next

                    largeX = largeX * K_2deg_C
                    largeY = largeY * K_2deg_C
                    largeZ = largeZ * K_2deg_C
                Else
                    Return Nothing
                    Exit Function
                End If

            ElseIf degree = "10 Degree" Then  '10 Degree
                If lightsource = "D65" Then
                    For i = 0 To UBound(measuredSpectrum)
                        largeX += D65_5nm(i) * CMF_x_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeY += D65_5nm(i) * CMF_y_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeZ += D65_5nm(i) * CMF_z_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                    Next

                    largeX = largeX * K_10deg_D65
                    largeY = largeY * K_10deg_D65
                    largeZ = largeZ * K_10deg_D65
                ElseIf lightsource = "C" Then
                    For i = 0 To UBound(measuredSpectrum)
                        largeX += C_5nm(i) * CMF_x_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeY += C_5nm(i) * CMF_y_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                        largeZ += C_5nm(i) * CMF_z_bar_10deg_5nm(i) * measuredSpectrum(i) / 100.0
                    Next

                    largeX = largeX * K_10deg_C
                    largeY = largeY * K_10deg_C
                    largeZ = largeZ * K_10deg_C
                Else
                    Return Nothing
                    Exit Function
                End If

            Else
                Return Nothing
                Exit Function
            End If

        Else
            Return Nothing
            Exit Function
        End If

        retArray = {largeX, largeY, largeZ}

        Return retArray

    End Function

    Public Function calculate_xy1931(XYZarray() As Single) As Single() '
        Dim x1931, y1931 As Single
        Dim retArray(1) As Single
        x1931 = 0
        y1931 = 0

        x1931 = XYZarray(0) / (XYZarray(0) + XYZarray(1) + XYZarray(2))
        y1931 = XYZarray(1) / (XYZarray(0) + XYZarray(1) + XYZarray(2))

        retArray = {x1931, y1931}

        Return retArray
    End Function
    Public Function calculate_XnYnZn_10deg_D65() As Single()
        Dim Xn, Yn, Zn As Single
        Dim reference As Single
        Dim retArray() As Single
        Dim i As Integer
        Xn = 0
        Yn = 0
        Zn = 0

        For i = 0 To UBound(D65_5nm)
            Xn += D65_5nm(i) * CMF_x_bar_10deg_5nm(i)
            Yn += D65_5nm(i) * CMF_y_bar_10deg_5nm(i)
            Zn += D65_5nm(i) * CMF_z_bar_10deg_5nm(i)
        Next i

        reference = Yn

        Xn = Xn * (100.0 / reference)
        Yn = Yn * (100.0 / reference)
        Zn = Zn * (100.0 / reference)

        'Debug.Print("XnYnZn_10deg_D65 : " & Xn & "," & Yn & "," & Zn)

        retArray = {Xn, Yn, Zn}
        Return retArray
    End Function
    Public Function calculate_XnYnZn_2deg_D65() As Single()
        Dim Xn, Yn, Zn As Single
        Dim reference As Single
        Dim retArray() As Single
        Dim i As Integer
        Xn = 0
        Yn = 0
        Zn = 0

        For i = 0 To UBound(D65_5nm)
            Xn += D65_5nm(i) * CMF_x_bar_2deg_5nm(i)
            Yn += D65_5nm(i) * CMF_y_bar_2deg_5nm(i)
            Zn += D65_5nm(i) * CMF_z_bar_2deg_5nm(i)
        Next i

        reference = Yn

        Xn = Xn * (100.0 / reference)
        Yn = Yn * (100.0 / reference)
        Zn = Zn * (100.0 / reference)

        'Debug.Print("XnYnZn_2deg_D65 : " & Xn & "," & Yn & "," & Zn)

        retArray = {Xn, Yn, Zn}
        Return retArray
    End Function

    Public Function calculate_XnYnZn_2deg_C() As Single()
        Dim Xn, Yn, Zn As Single
        Dim reference As Single
        Dim retArray() As Single
        Dim i As Integer
        Xn = 0
        Yn = 0
        Zn = 0

        For i = 0 To UBound(C_5nm)
            Xn += C_5nm(i) * CMF_x_bar_2deg_5nm(i)
            Yn += C_5nm(i) * CMF_y_bar_2deg_5nm(i)
            Zn += C_5nm(i) * CMF_z_bar_2deg_5nm(i)
        Next i

        reference = Yn

        Xn = Xn * (100.0 / reference)
        Yn = Yn * (100.0 / reference)
        Zn = Zn * (100.0 / reference)

        'Debug.Print("XnYnZn_2deg_C : " & Xn & "," & Yn & "," & Zn)

        retArray = {Xn, Yn, Zn}
        Return retArray
    End Function

    Public Function calculate_XnYnZn_10deg_C() As Single()
        Dim Xn, Yn, Zn As Single
        Dim reference As single
        Dim retArray() As Single
        Dim i As Integer
        Xn = 0
        Yn = 0
        Zn = 0

        For i = 0 To UBound(C_5nm)
            Xn += C_5nm(i) * CMF_x_bar_10deg_5nm(i)
            Yn += C_5nm(i) * CMF_y_bar_10deg_5nm(i)
            Zn += C_5nm(i) * CMF_z_bar_10deg_5nm(i)
        Next i

        reference = Yn

        Xn = Xn * (100.0 / reference)
        Yn = Yn * (100.0 / reference)
        Zn = Zn * (100.0 / reference)

        ' Debug.Print("XnYnZn_10deg_C : " & Xn & "," & Yn & "," & Zn)
        retArray = {Xn, Yn, Zn}
        Return retArray
    End Function
    Public Function calculate_Lab_Star(XYZarray() As Single, degree As String, lightSource As String) As Single() 'only from X,Y,Z
        Dim X, Y, Z As Single
        Dim Xn, Yn, Zn As Single
        Dim Lstar, astar, bstar As Single
        Dim retArray(2) As Single

        X = XYZarray(0)
        Y = XYZarray(1)
        Z = XYZarray(2)

        If degree = "2 Degree" Then ' 2 Degree or 10 Degree
            If lightSource = "D65" Then
                Xn = Xn_2deg_D65
                Yn = Yn_2deg_D65
                Zn = Zn_2deg_D65
            ElseIf lightSource = "C" Then
                Xn = Xn_2deg_C
                Yn = Yn_2deg_C
                Zn = Zn_2deg_C
            End If
        ElseIf degree = "10 Degree" Then
            If lightSource = "D65" Then
                Xn = Xn_10deg_D65
                Yn = Yn_10deg_D65
                Zn = Zn_10deg_D65
            ElseIf lightSource = "C" Then
                Xn = Xn_10deg_C
                Yn = Yn_10deg_C
                Zn = Zn_10deg_C
            End If
        End If

        Lstar = 116 * calculate_function(Y / Yn) - 16
        astar = 500 * (calculate_function(X / Xn) - calculate_function(Y / Yn))
        bstar = 200 * (calculate_function(Y / Yn) - calculate_function(Z / Zn))

        retArray = {Lstar, astar, bstar}

        Return retArray
    End Function
    Public Function calculate_function(a As Single) As Single
        Dim retValue As Single

        If a > (6 / 29) ^ 3 Then
            retValue = a ^ (1 / 3)
        Else
            retValue = (841 / 108) * a + 4 / 29
        End If

        Return retValue
    End Function
    Public Function calculate_YI_ASTM_E313_73(measuredSpectrum() As Single) As Single
        Dim X, Y, Z As Single
        Dim YI_ASTM_E313_73 As Single
        Dim XYZ(2) As Single
        XYZ = calculate_XYZ(measuredSpectrum, "2 Degree", "C")
        X = XYZ(0)
        Y = XYZ(1)
        Z = XYZ(2)

        YI_ASTM_E313_73 = 100 * (1 - 0.847 * Z / Y)

        Return YI_ASTM_E313_73

    End Function
End Module
